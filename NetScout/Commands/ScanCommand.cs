using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetScout.Commands
{
    internal class ScanCommand
    {
        private static readonly Dictionary<int, string> CommonPorts = new()
        {
            { 21, "FTP" },
            { 22, "SSH" },
            { 23, "Telnet" },
            { 25, "SMTP" },
            { 53, "DNS" },
            { 80, "HTTP" },
            { 110, "POP3" },
            { 135, "RPC" },
            { 139, "NetBIOS" },
            { 443, "HTTPS" },
            { 445, "SMB" },
            { 3306, "MySQL" },
            { 3389, "RDP" },
            { 8080, "HTTP-alt" }
        };
        public static void Run(string host)
        {
            Console.WriteLine($"Skeniram {host} ...\n");
            int open = 0;

            foreach (var entry in CommonPorts)
            {
                int port = entry.Key;
                string service = entry.Value;

                if (IsPortOpen(host, port, 500))
                {
                    Console.WriteLine($"Port {port} ({service}): OTVOREN");
                    open++;
                }
            }

            Console.WriteLine($"\nSkenirano portova: {CommonPorts.Count}, otvorenih: {open}");
        }
        private static bool IsPortOpen(string host, int port, int timeoutMs)
        {
            try
            {
                using var client = new TcpClient();
                Task connectTask = client.ConnectAsync(host, port);
                return connectTask.Wait(timeoutMs) && client.Connected;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
