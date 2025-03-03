using PacketDotNet;
using System;

namespace SwitchApp;

public static class ProtocolDetector
{
    public static string Detect(Packet packet)
    {
        // 1. Detekcia Ethernet II
        var ethPacket = packet.Extract(typeof(EthernetPacket)) as EthernetPacket;
        if (ethPacket == null) return "Other";

        // 2. Detekcia ARP
        if (ethPacket.Type == EthernetPacketType.Arp)
            return "ARP";

        // 3. Detekcia IPv4/IPv6
        var ip4Packet = packet.Extract(typeof(IPv4Packet)) as IPv4Packet;
        var ip6Packet = packet.Extract(typeof(IPv6Packet)) as IPv6Packet;

        IPProtocolType? protocol = null;
        bool isIpv6 = false;

        // Rozlíšenie medzi IPv4 a IPv6
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
            return "Ethernet II"; // Nie je IP paket
        }

        // 4. Detekcia ICMP/ICMPv6
        if (protocol == IPProtocolType.ICMP || (isIpv6 && protocol == IPProtocolType.ICMPV6))
            return "ICMP";

        // 5. Detekcia TCP
        if (protocol == IPProtocolType.TCP)
        {
            var tcpPacket = packet.Extract(typeof(TcpPacket)) as TcpPacket;
            if (tcpPacket == null) return "TCP";

            // 6. Detekcia HTTP podľa portov
            if (tcpPacket.SourcePort == 80 || tcpPacket.DestinationPort == 80 ||
                tcpPacket.SourcePort == 443 || tcpPacket.DestinationPort == 443)
                return "HTTP";

            return "TCP";
        }

        // 7. Detekcia UDP
        if (protocol == IPProtocolType.UDP)
            return "UDP";

        // 8. Ostatné IP protokoly
        return "IP";
    }
}