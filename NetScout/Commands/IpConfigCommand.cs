using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace NetScout.Commands
{
    internal class IpConfigCommand
    {
        public static void Run()
        {
            Console.WriteLine("================================");
            NetworkInterface[] adapteri = NetworkInterface.GetAllNetworkInterfaces();
            if(adapteri.Length!=0)
            {
                foreach(NetworkInterface adapter in adapteri)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up && adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback && adapter.NetworkInterfaceType!=NetworkInterfaceType.Tunnel)
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Ime: " + adapter.Name);
                        Console.WriteLine("Tip: " + adapter.NetworkInterfaceType);
                        Console.WriteLine("Status: " + adapter.OperationalStatus);
                        byte[] bajtovi = adapter.GetPhysicalAddress().GetAddressBytes();
                        Console.WriteLine("MAC Adresa: " + BitConverter.ToString(bajtovi));
                        IPInterfaceProperties IpProperties = adapter.GetIPProperties();
                        foreach (var ip in IpProperties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                Console.WriteLine("\nIPv4 Adresa: " + ip.Address);
                                Console.WriteLine("Subnet Mask: " + ip.IPv4Mask);
                            }
                        }
                        if (IpProperties.GatewayAddresses.Count == 0)
                        {
                            Console.WriteLine("Default Gateway: ");
                        }
                        foreach (GatewayIPAddressInformation gateway in IpProperties.GatewayAddresses)
                        {
                            if (gateway.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                Console.WriteLine("Default Gateway: " + gateway.Address);
                            }
                        }
                        Console.WriteLine("DNS Serveri:");
                        foreach (IPAddress dns in IpProperties.DnsAddresses)
                        {
                            if (dns.AddressFamily == AddressFamily.InterNetwork)
                            {
                                Console.WriteLine(dns);
                            }
                        }
                        Console.WriteLine("================================");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nije moguce izvrsiti komandu!");
            }
        }
    }
}
