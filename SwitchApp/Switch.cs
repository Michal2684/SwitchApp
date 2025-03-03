using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;
using System.Security.Cryptography;
using SharpPcap;
using PacketDotNet;
using SharpPcap.LibPcap;


namespace SwitchApp;

public class Switch: IDisposable
{
    private readonly ConcurrentDictionary<string, DateTime> _sentFrames = new();
    private readonly TimeSpan _frameTtl = TimeSpan.FromSeconds(1);
    private System.Timers.Timer _cleanupTimer;
    
    
    private readonly Dictionary<int, PortStats> _portStats = new()
    {
        { 1, new PortStats() },
        { 2, new PortStats() }
    };
    public IReadOnlyDictionary<int, PortStats> PortStatistics => _portStats;
    
    private LibPcapLiveDevice? _port1;
    private LibPcapLiveDevice? _port2;
    
    
    public void Start()
    {
        InitializePorts();
        InitializeTimers(); 
        StartCapture(_port1);
        StartCapture(_port2);

    }

    private void InitializePorts()
    {
        // Získajte všetky dostupné zariadenia
        var allDevices = CaptureDeviceList.Instance
            .Cast<LibPcapLiveDevice>()
            .ToList();

        // Debug výpis pre kontrolu
        Console.WriteLine("Dostupné sieťové rozhrania:");
        foreach (var device in allDevices)
        {
            Console.WriteLine($"- {device.Description} ({device.Name})");
        }

        // Filtrujte adaptéry podľa popisu (prispôsobte podľa vášho výpisu)
        var usbAdapters = allDevices
            .Where(d => d.Description.Contains("Realtek USB GbE", StringComparison.OrdinalIgnoreCase))
            .Take(2)
            .ToList();

        // Overte počet
        if (usbAdapters.Count < 2)
        {
            throw new InvalidOperationException(
                "Nenašli sa 2 Realtek USB adaptéry. Skontrolujte:\n" +
                "1. Sú adaptéry pripojené?\n" +
                "2. Sú povolené v Sieťových pripojeniach?\n" +
                "3. Obsahuje popis adaptéra 'Realtek USB GbE'?"
            );
        }

        // Priradenie portov
        _port1 = usbAdapters[0];
        _port2 = usbAdapters[1];

        Console.WriteLine($"Vybrané porty:\n" +
                          $"Port 1: {_port1.Description}\n" +
                          $"Port 2: {_port2.Description}");

        // Otvorenie portov
        _port1.Open(DeviceMode.Promiscuous, 1000);
        _port2.Open(DeviceMode.Promiscuous, 1000);
    }

    private void InitializeTimers()
    {
        _cleanupTimer = new System.Timers.Timer(1000);
        _cleanupTimer.Elapsed += (_,_) => CleanupOldFrames();
        _cleanupTimer.Start();
    }

    private void CleanupOldFrames()
    {
        var cutoff = DateTime.Now - _frameTtl;
        foreach (var hash in _sentFrames.Where(kv => kv.Value < cutoff).Select(kv => kv.Key).ToList())
        {
            _sentFrames.TryRemove(hash, out _);
        }
    }
    
    private void StartCapture(LibPcapLiveDevice device)
    {
        device.OnPacketArrival += (s, e) => 
        {
            var rawPacket = e.Packet; 
            if (rawPacket != null)
            {
                ProcessPacket(rawPacket, device);
            }
        };
        device.StartCapture();
    }
    private void ProcessPacket(RawCapture rawPacket, LibPcapLiveDevice ingressPort)
    {
        Console.WriteLine($"Paket prijatý na porte {(ingressPort == _port1 ? 1 : 2)}");
        var hash = ComputeHash(rawPacket.Data);
        var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
        if (packet == null) return;
        
        if (_sentFrames.ContainsKey(hash))
        {
            var protocol = ProtocolDetector.Detect(packet);
            var portNumber = ingressPort == _port1 ? 1 : 2;
            UpdateStats(portNumber, protocol, isIncoming: true);
            return;
        }
            
        
        ForwardPacket(packet, ingressPort);
        
    }
    private void ForwardPacket(Packet packet, LibPcapLiveDevice ingressPort)
    {
        //var eth = packet.Extract<EthernetPacket>();
        
        FloodPorts(packet, ingressPort);
        
    }

    private void FloodPorts(Packet packet, LibPcapLiveDevice ingressPort)
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
            var data = packet.Bytes;
            var hash = ComputeHash(data);
            
            port.SendPacket(packet.Bytes);
            
            if (_sentFrames.TryAdd(hash, DateTime.Now))
            {
                var protocol = ProtocolDetector.Detect(packet);
                var portNumber = port == _port1 ? 1 : 2;
                UpdateStats(portNumber, protocol, isIncoming: false);
            }
        }
        catch (Exception e){Console.WriteLine($"Chyba: {e.Message}"); }   
        
    }
    
    private string ComputeHash(byte[] data)
    {
        return BitConverter.ToString(data, 0, Math.Min(8, data.Length)).Replace("-", "");
    }

    private void UpdateStats(int port, string protocol, bool isIncoming)
    {
        var stats = isIncoming ? _portStats[port].In : _portStats[port].Out;
        stats[protocol] = stats.TryGetValue(protocol, out var count) ? count + 1 : 1;
        
    }
    
    public void ResetStats()
    {
        foreach (var port in _portStats.Values)
        {
            port.In.Clear();
            port.Out.Clear();
        }
    }
    
    public void Dispose()
    {
        _cleanupTimer.Stop();
        _cleanupTimer.Dispose();
        _port1.StopCapture();
        _port2.StopCapture();
    }
}



















