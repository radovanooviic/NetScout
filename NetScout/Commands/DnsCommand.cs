using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetScout.Commands
{
    internal class DnsCommand
    {
        public static void ForwardRun(string host)
        {
            IPAddress[] adrese = Dns.GetHostAddresses(host);
            foreach (IPAddress ad in adrese)
            {
                if (ad.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"IPv4: {ad}");
                }
                else if (ad.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    Console.WriteLine($"IPv6: {ad}");
                }
            }
        }
        public static void ReverseRun(string ipAdress)
        {
            try
            {
                IPAddress adresa = IPAddress.Parse(ipAdress);
                IPHostEntry host = Dns.GetHostEntry(adresa);
                Console.WriteLine($"HostName: {host.HostName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
