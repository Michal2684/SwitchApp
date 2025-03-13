using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.IO.Hashing;
using System.Timers;
using SharpPcap;
using PacketDotNet;
using SharpPcap.LibPcap;

namespace SwitchApp;

public class Switch : IDisposable
{
    private readonly TimeSpan _frameTtl = TimeSpan.FromSeconds(5);
    private System.Timers.Timer _cleanupTimer;
    private readonly ConcurrentDictionary<string, DateTime> _frameHashes = new();

    private readonly Dictionary<int, PortStats> _portStats = new()
    {
        { 1, new PortStats() },
        { 2, new PortStats() }
    };

    public List<object> GetAvailableDevices()
    {
        var devices = CaptureDeviceList.Instance.Cast<LibPcapLiveDevice>().ToList();

        var modifiedDevices = devices.Select(device => new
        {
            Device = device,
            Description = device.Description.StartsWith("Network adapter")
                ? device.Description.Substring("Network adapter".Length).Trim()
                : device.Description
        }).ToList();

        return modifiedDevices.Cast<object>().ToList();
    }

    public IReadOnlyDictionary<int, PortStats> PortStatistics => _portStats;

    private LibPcapLiveDevice? _port1;
    private LibPcapLiveDevice? _port2;

    public void Start()
    {
        if (_port1 == null || _port2 == null)
            throw new InvalidOperationException("Ports not initialized");

        TimerInitialization();
        StartCapture(_port1);
        StartCapture(_port2);
    }

    public void InitializePorts(LibPcapLiveDevice port1, LibPcapLiveDevice port2)
    {
        if (port1 == null || port2 == null)
        {
            Console.WriteLine("Port1 is null: " + (port1 == null));
            Console.WriteLine("Port2 is null: " + (port2 == null));
            throw new ArgumentNullException("Both ports must be selected");
        }

        if (port1.Name == port2.Name)
            throw new ArgumentException("Cannot use the same interface for both ports");

        _port1 = port1;
        _port2 = port2;

        Console.WriteLine($"Selected ports:\nPort 1: {_port1.Description}\nPort 2: {_port2.Description}");
        _port1.Open(DeviceMode.Promiscuous, 100);
        _port2.Open(DeviceMode.Promiscuous, 100);
    }

    private void TimerInitialization()
    {
        _cleanupTimer = new System.Timers.Timer(1000);
        _cleanupTimer.Elapsed += (_, _) => RemoveFrames();
        _cleanupTimer.Start();
    }

    private void RemoveFrames()
    {
        var now = DateTime.Now;
        var expiredHashes = _frameHashes.Where(kv => now - kv.Value > _frameTtl)
                                        .Select(kv => kv.Key)
                                        .ToList();
        
        foreach (var hash in expiredHashes)
        {
            _frameHashes.TryRemove(hash, out _);
        }
    }

    private void StartCapture(LibPcapLiveDevice device)
    {
        device.OnPacketArrival += (s, e) =>
        {
            var rawPacket = e.Packet;
            if (rawPacket != null)
            {
                ProcessPacketStream(rawPacket, device);
            }
        };
        device.StartCapture();
    }

    private string ComputePacketHash(RawCapture rawPacket)
    {
        if (rawPacket.Data == null || rawPacket.Data.Length == 0)
            return string.Empty;

        var crc = new Crc32();
        crc.Append(rawPacket.Data);
        return Convert.ToHexString(crc.GetCurrentHash());
    }
    private void ProcessPacketStream(RawCapture rawPacket, LibPcapLiveDevice entryPort)
    {
        Console.WriteLine($"Paket prijatý na porte {(entryPort == _port1 ? 1 : 2)}");
        
        var packetHash = ComputePacketHash(rawPacket);
        if (_frameHashes.ContainsKey(packetHash))
        {
            Console.WriteLine("Duplicate packet detected, dropping.");
            return;
        }
        
        _frameHashes.TryAdd(packetHash, DateTime.Now);

        var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
        if (packet == null) return;
        
        var protocol = ProtocolDetector.Detect(packet);
        var portNumber = entryPort == _port1 ? 1 : 2;
        UpdateStats(portNumber, protocol, isIncoming: true);

        ForwardPacketStream(packet, entryPort);
    }

    private void ForwardPacketStream(Packet packet, LibPcapLiveDevice ingressPort)
    {
        FloodAllPorts(packet, ingressPort);
    }

    private void FloodAllPorts(Packet packet, LibPcapLiveDevice ingressPort)
    {
        foreach (var port in new[] { _port1, _port2 }.Where(p => p != ingressPort))
        {
            SendPacket(packet, port);
        }
    }

    private void SendPacket(Packet packet, LibPcapLiveDevice port)
    {
        try
        {
            port.SendPacket(packet.Bytes);

            var protocol = ProtocolDetector.Detect(packet);
            var portNumber = port == _port1 ? 1 : 2;
            UpdateStats(portNumber, protocol, isIncoming: false);
        }
        catch (Exception e) { Console.WriteLine($"Chyba: {e.Message}"); }
    }

    private void UpdateStats(int port, string protocol, bool isIncoming)
    {
        var stats = isIncoming ? _portStats[port].In : _portStats[port].Out;
        if (stats.TryGetValue(protocol, out var count))
        {
            stats[protocol] = count + 1;
        }
        else
        {
            stats[protocol] = 1;
        }
    }

    public void ResetStats()
    {
        foreach (var port in _portStats.Values)
        {
            port.In.Clear();
            port.Out.Clear();
        }
        _frameHashes.Clear();
    }

    public void Dispose()
    {
        _cleanupTimer?.Stop();
        _cleanupTimer?.Dispose();

        if (_port1 != null)
        {
            _port1.StopCapture();
            _port1.Close();
        }

        if (_port2 != null)
        {
            _port2.StopCapture();
            _port2.Close();
        }

        _port1 = null;
        _port2 = null;
    }
}