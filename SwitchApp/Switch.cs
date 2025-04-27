using System.IO.Hashing;
using System.Collections.Concurrent;
using System.Timers;
using SharpPcap;
using PacketDotNet;
using SharpPcap.LibPcap;

namespace SwitchApp;


public enum AclDirection { Inbound, Outbound }
public enum AclAction { Permit, Deny }

public class AclRule
{
    public int Id { get; set; }
    public AclDirection Direction { get; set; }
    public AclAction Action { get; set; }
    public int? Port { get; set; }  
    public string? SrcMac { get; set; } 
    public string? DstMac { get; set; }
    public string? SrcIp { get; set; }
    public string? DstIp { get; set; }
    public int? SrcPort { get; set; }  
    public int? DstPort { get; set; }
    public byte? IcmpType { get; set; } 
}
public class Switch : IDisposable
{
    private int _timeout = 60000; 
    private System.Timers.Timer? _timer; 
    private readonly ConcurrentDictionary<string, DateTime> _pkts = new(); 
    private readonly ConcurrentDictionary<string, MacEntry> _macTable = new();
    
    public Dictionary<int, PortStats> Stats => _stats; 
    private Dictionary<int, PortStats> _stats;

    private LibPcapLiveDevice? _p1;
    private LibPcapLiveDevice? _p2;
    
    private readonly List<AclRule> _aclRules = new List<AclRule>();
    private int _nextRuleId = 1; 
    public IReadOnlyList<AclRule> AclRules => _aclRules;
    
    private class MacEntry
    {
        public int Port { get; set; }
        public DateTime LastSeen { get; set; }
    }

    public int TimeoutSeconds
    {
        get => _timeout / 1000;
        set => _timeout = value * 1000;
    }

    public Switch()
    {
        _stats = new Dictionary<int, PortStats>();
        _stats[1] = new PortStats();
        _stats[2] = new PortStats();
    }

    public List<object> GetAvailableDevices()
    {
        var result = new List<object>();
        foreach (var dev in CaptureDeviceList.Instance)
        {
            if (dev is LibPcapLiveDevice device)
            {
                string description;
                if (device.Description.StartsWith("Network adapter"))
                {
                    description = device.Description
                        .Substring("Network adapter".Length).Trim();
                }
                else
                {
                    description = device.Description;
                }
                
                result.Add(new
                {
                    Device = device,
                    Description = description
                });
            }
        }
        return result;
    }
    public void Start()
    {
        if (_p1 == null || _p2 == null)
            throw new Exception("Ports not init");

        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += Cleanup;
        _timer.Start();

        _p1.OnPacketArrival += (_, e) => Process(e.Packet, _p1);
        
        _p2.OnPacketArrival += (_, e) => Process(e.Packet, _p2);
        

        _p1.StartCapture();
        _p2.StartCapture();
    }

    private void Cleanup(object? s, ElapsedEventArgs e)
    {
        var oldPackets = new List<string>();
        foreach (var k in _pkts.Keys)
        {
            if ((DateTime.Now - _pkts[k]).TotalMilliseconds > _timeout)
                oldPackets.Add(k);
        }
        foreach (var k in oldPackets)
        {
            _pkts.TryRemove(k, out _);
        }
        
        var oldMacs = new List<string>();
        foreach (var kv in _macTable)
        {    
            if ((DateTime.Now - kv.Value.LastSeen).TotalMilliseconds > _timeout)
                oldMacs.Add(kv.Key);
        }
        foreach (var mac in oldMacs)
        {
            _macTable.TryRemove(mac, out _);
        }
    }
    
    public void ClearMacTable() => _macTable.Clear();

    public Dictionary<string, (int Port, int RemainingSeconds)> GetMacTable()
    {
        var result = new Dictionary<string, (int Port, int RemainingSeconds)>();
        
        foreach (var k in _macTable)
        {
            string mac = k.Key;
            int port = k.Value.Port;
            
            double elapsedMs = (DateTime.Now - k.Value.LastSeen).TotalMilliseconds;
            int remainingSec = (int)((_timeout - elapsedMs) / 1000);
            
            result[mac] = (port, remainingSec);
        }

        return result;
    }

    public void ResetStats()
    {
        _stats[1].In.Clear();
        _stats[1].Out.Clear();
        _stats[2].In.Clear();
        _stats[2].Out.Clear();
    }
    
    public void SetupPorts(LibPcapLiveDevice portA, LibPcapLiveDevice portB)
    {
        if (portA == null || portB == null) 
            throw new ArgumentException("Bad ports");

        if (portA.Name == portB.Name)
            throw new ArgumentException("Duplicate ports");

        _p1 = portA;
        _p2 = portB;

        Console.WriteLine($"Port1: {_p1.Description.Substring(0, 15)}...");
        Console.WriteLine($"Port2: {_p2.Description.Substring(0, 15)}...");
        
        try
        {
            _p1.Open(DeviceMode.Promiscuous, 100);
            _p2.Open(DeviceMode.Promiscuous, 100);
        }
        catch
        {
            Console.WriteLine("Error opening promiscuous device");
        }
    }

    private void Process(RawCapture? pkt, LibPcapLiveDevice srcPort)
    {
        if (pkt == null || _p1 == null || _p2 == null) return;
        
        var parsed = Packet.ParsePacket(pkt.LinkLayerType, pkt.Data);
        if (parsed == null) return;
        var ethPacket = parsed.Extract(typeof(EthernetPacket)) as EthernetPacket;
        if (ethPacket == null) return;

        int ingressPort = srcPort == _p1 ? 1 : 2;
        
        if (!EvaluateAcls(ethPacket , parsed, ingressPort, isIncoming: true))
            return;
        
        var hash = MakeHash(pkt);
        if (_pkts.ContainsKey(hash))
        {
            return;
        }
        _pkts[hash] = DateTime.Now;
        
        
        var srcMac = ethPacket.SourceHwAddress.ToString();
        int port = srcPort == _p1 ? 1 : 2;

        if (ethPacket.SourceHwAddress.ToString() != "FF:FF:FF:FF:FF:FF")
        {

            _macTable.AddOrUpdate(srcMac,
                new MacEntry { Port = port, LastSeen = DateTime.Now },
                (_, existing) =>
                {
                    existing.Port = port;
                    existing.LastSeen = DateTime.Now;
                    return existing;
                });
        }
        

        var destMac = ethPacket.DestinationHwAddress.ToString();
        var protocol = ProtocolDetector.Detect(parsed);
        
        if (destMac == "FF:FF:FF:FF:FF:FF")
            FloodPacket(parsed, ethPacket, srcPort, protocol);
        else
            ForwardToMac(parsed, ethPacket, destMac, srcPort, protocol);

    

        UpdateCounters(srcPort == _p1 ? 1 : 2, ProtocolDetector.Detect(parsed), true);
    }
    
    
    private bool EvaluateAcls(EthernetPacket ethPacket, Packet parsed, int ingressPort, bool isIncoming){
    foreach(var rule in _aclRules)
    {
        

        if ((rule.Direction == AclDirection.Inbound  && !isIncoming) || (rule.Direction == AclDirection.Outbound &&  isIncoming))
            continue;

        //------------ETH PORT-----------
        if (rule.Port.HasValue && rule.Port.Value != ingressPort)
            continue;

        //------------MAC-----------
        if (!string.IsNullOrEmpty(rule.SrcMac) &&
            !rule.SrcMac.Equals(ethPacket.SourceHwAddress.ToString(), StringComparison.OrdinalIgnoreCase))
            continue;
        if (!string.IsNullOrEmpty(rule.DstMac) &&
            !rule.DstMac.Equals(ethPacket.DestinationHwAddress.ToString(), StringComparison.OrdinalIgnoreCase))
            continue;

        //-----------IP------------
        var ip4 = parsed.Extract(typeof(IPv4Packet)) as IPv4Packet;
        var ip6 = parsed.Extract(typeof(IPv6Packet)) as IPv6Packet;
        string? sip = ip4?.SourceAddress.ToString() ?? ip6?.SourceAddress.ToString();
        string? dip = ip4?.DestinationAddress.ToString() ?? ip6?.DestinationAddress.ToString();

        if (!string.IsNullOrEmpty(rule.SrcIp) &&
            !rule.SrcIp.Equals(sip, StringComparison.OrdinalIgnoreCase))
            continue;
        if (!string.IsNullOrEmpty(rule.DstIp) &&
            !rule.DstIp.Equals(dip, StringComparison.OrdinalIgnoreCase))
            continue;

        //-----------------TCP/UDP PORTS----------------------
        var tcp = parsed.Extract(typeof(TcpPacket)) as TcpPacket;
        var udp = parsed.Extract(typeof(UdpPacket)) as UdpPacket;
        if (rule.SrcPort.HasValue)
        {
            var sp = tcp?.SourcePort ?? udp?.SourcePort;
            if (sp == null || sp.Value != rule.SrcPort.Value) continue;
        }
        if (rule.DstPort.HasValue)
        {
            var dp = tcp?.DestinationPort ?? udp?.DestinationPort;
            if (dp == null || dp.Value != rule.DstPort.Value) continue;
        }

        //-------------ICMP-------------------
        if (rule.IcmpType.HasValue)
        {
            var icmp4 = parsed.Extract(typeof(ICMPv4Packet)) as ICMPv4Packet;
            var icmp6 = parsed.Extract(typeof(ICMPv6Packet)) as ICMPv6Packet;

            if (icmp4 != null)
            {
                if ((byte)icmp4.TypeCode != rule.IcmpType.Value) continue;
            }
            else if (icmp6 != null)
            {
                if ((byte)icmp6.Type != rule.IcmpType.Value) continue;
            }
            else
            {
                continue;
            }

        }
        return rule.Action == AclAction.Permit;
    }
    
    return true;
    }

    private void ForwardToMac(Packet parsed,EthernetPacket eth, string destMac, LibPcapLiveDevice srcPort, string protocol)
    {
        if (_macTable.TryGetValue(destMac, out var entry))
        {
            int egressPort = entry.Port;
            var target = (egressPort == 1 ? _p1 : _p2)!;

            if (srcPort == target) 
                return;
            
            if (!EvaluateAcls(eth, parsed, egressPort, isIncoming: false))
                return;
            
            try
            {
                target.SendPacket(parsed.Bytes);
                UpdateCounters(egressPort, protocol, incoming: false);
            }
            catch (PcapException ex)
            {
                Console.WriteLine($"Error while sending to {egressPort}: {ex.Message}");
            }
        }
        else
        {
            FloodPacket(parsed,eth, srcPort, protocol);
        }
    }
    

    private void FloodPacket(Packet parsed, EthernetPacket eth, LibPcapLiveDevice srcPort, string protocol)
    {
        foreach (var (portNum, dev) in new[] { (1, _p1), (2, _p2) })
        {
            if (dev == null || dev == srcPort) 
                continue;
            
            if (!EvaluateAcls(eth, parsed, portNum, isIncoming: false))
                continue;

            try
            {
                dev.SendPacket(parsed.Bytes);
                UpdateCounters(portNum, protocol, incoming: false);
            }
            catch (PcapException ex)
            {
                Console.WriteLine($"Error while flooding to port {portNum}: {ex.Message}");
            }
        }
    }
    

    private void UpdateCounters(int port, string proto, bool incoming)
    {
        var dict = incoming ? _stats[port].In : _stats[port].Out;
        if (dict.ContainsKey(proto))
            dict[proto]++;
        else
            dict[proto] = 1;
    }
    
    public AclRule AddRule(AclRule template)
    {
        template.Id = _nextRuleId++;
        _aclRules.Add(template);
        return template;
    }

    public bool RemoveRule(int id) => _aclRules.RemoveAll(r => r.Id == id) > 0;

    public void ClearRules()
    {
        _aclRules.Clear();
        _nextRuleId = 1;
    }
    
    public void Dispose()
    {
        _timer?.Stop();
        _p1?.StopCapture();
        _p2?.StopCapture();
        
    }
    private string MakeHash(RawCapture rawPacket)
    {
        if (rawPacket.Data == null || rawPacket.Data.Length == 0)
            return string.Empty;
        
        var crc = new Crc32();
        crc.Append(rawPacket.Data.AsSpan());
        byte[] hashBytes = crc.GetCurrentHash();
        
        return Convert.ToHexString(hashBytes);
    }
}