using NetScout.Commands;
internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Upotreba: netscout <komanda> [argumenti]. Koristite --help.");
            Environment.Exit(1);
        }
        switch (args[0])//args[0] je koja je komanda pozvan npr netscout --help
        {
            case "--help":
                Console.WriteLine("NetScout --version da bi videli verziju alata");
                Console.WriteLine("NetScout -ping ip_adress za pingovanje");
                Console.WriteLine("NetScout -scan ip_adress za trazenje portova");
                break;
            case "--version":
                Console.WriteLine("NetScout v1.0");
                break;
            case "-ping":
                if (args.Length < 2)
                {
                    Console.WriteLine("Morate uneti ip adresu!");
                    Environment.Exit(1);
                }
                PingCommand.Run(args[1]);
                break;
            case "-scan":
                if (args.Length < 2)
                {
                    Console.WriteLine("Morate uneti ip adresu!");
                    Environment.Exit(1);
                }
                ScanCommand.Run(args[1]);
                break;
            default:
                Console.WriteLine($"Nepoznat argument: {args[0]}");
                Environment.Exit(1);
                break;
        }
    }
}