using PacketDotNet;
using System;

namespace SwitchApp;

public static class ProtocolDetector
{
    public static string Detect(Packet packet)
    {
        var ethPacket = packet.Extract(typeof(EthernetPacket)) as EthernetPacket;
        if (ethPacket == null) return "Other";
        
        if (ethPacket.Type == EthernetPacketType.Arp)
            return "ARP";
        
        var ip4Packet = packet.Extract(typeof(IPv4Packet)) as IPv4Packet;
        var ip6Packet = packet.Extract(typeof(IPv6Packet)) as IPv6Packet;

        IPProtocolType? protocol = null;
        bool isIpv6 = false;
        
        if (ip4Packet != null)
        {
            protocol = ip4Packet.Protocol;
        }
        else if (ip6Packet != null)
        {
            protocol = ip6Packet.NextHeader;
            isIpv6 = true;
        }
        else
        {
            return "EthernetII"; 
        }
        
        if (protocol == IPProtocolType.ICMP || (isIpv6 && protocol == IPProtocolType.ICMPV6))
            return "ICMP";
        
        if (protocol == IPProtocolType.TCP)
        {
            var tcpPacket = packet.Extract(typeof(TcpPacket)) as TcpPacket;
            if (tcpPacket == null) return "TCP";
            
            if (tcpPacket.SourcePort == 80 || tcpPacket.DestinationPort == 80 ||
                tcpPacket.SourcePort == 443 || tcpPacket.DestinationPort == 443)
                return "HTTP";

            return "TCP";
        }
        
        if (protocol == IPProtocolType.UDP)
            return "UDP";
        
        return "IP";
    }
}