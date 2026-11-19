using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace NetScout.Commands
{
    internal class PingCommand
    {
        public static void Run(string ipAdress)
        {
			try
			{
                Ping pingSender = new Ping();
                int uspesno = 0;
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                for (int i = 0; i < 4; i++)
                {
                    PingReply reply = pingSender.Send(ipAdress, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        uspesno++;
                        Console.WriteLine($"Odgovor od {reply.Address}: vreme={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}");
                    }
                    else
                    {
                        Console.WriteLine($"Ping nije uspeo: {reply.Status}");
                    }
                }
                Console.WriteLine($"Poslato: 4, Primljeno: {uspesno}, Izgubljeno: {4 - uspesno}");
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
			}
        }
    }
}
