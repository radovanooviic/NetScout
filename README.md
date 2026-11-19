# NetScout

A small command-line network toolkit written in C# (.NET). Built as a learning project to explore sockets, ICMP, DNS and the `System.Net` namespaces.

## Features

| Command | Description |
|---|---|
| `--help` | Show available commands |
| `--version` | Show the current version |
| `--ping <ip>` | Send 4 ICMP echo requests and print the results |
| `--scan <ip>` | Scan common TCP ports and list the open ones |
| `--dns <host>` | Resolve a host name to its IP addresses |
| `--dns <ip> --reverse` | Reverse lookup: find the host name of an IP address |

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (8.0 or newer)
- Windows, Linux or macOS

## Getting started

```bash
git clone https://github.com/radovanooviic/NetScout.git
cd NetScout
dotnet build
dotnet run -- --help
```

The `--` separates arguments for `dotnet` from arguments for NetScout.

## Usage

```bash
# Show help
dotnet run -- --help

# Show version
dotnet run -- --version

# Ping a host
dotnet run -- --ping 8.8.8.8

# Scan common ports on your own machine
dotnet run -- --scan 127.0.0.1

# Resolve a host name to IP addresses
dotnet run -- --dns google.com

# Reverse lookup (IP to host name)
dotnet run -- --dns 8.8.8.8 --reverse
```

Example output of `--scan`:

```
Skeniram 127.0.0.1...

Port 135 (RPC): OTVOREN
Port 445 (SMB): OTVOREN

Skenirano portova: 14, otvorenih: 2
```

## How the port scan works

NetScout performs a simple **TCP connect scan**. For every port in a list of common ports it tries to open a TCP connection with a short timeout. If the connection succeeds, the port is reported as open. Closed and filtered ports are not listed.

Scanned ports: 21, 22, 23, 25, 53, 80, 110, 135, 139, 443, 445, 3306, 3389, 8080.

## How DNS lookup works

`--dns` has two modes:

- **Forward lookup** (`--dns <host>`): returns the IP addresses of a host name.
- **Reverse lookup** (`--dns <ip> --reverse`): returns the host name of an IP address. Many addresses have no reverse record, in which case no name can be found.

## Exit codes

| Code | Meaning |
|---|---|
| `0` | Success |
| `1` | Invalid usage (missing argument or unknown command) |

## Roadmap

- [x] `--dns` – resolve host names and IP addresses
- [ ] `--ipconfig` – show local network adapters
- [ ] `--sweep` – discover live hosts in a subnet
- [ ] `--traceroute` – show the path to a host
- [ ] Parallel port scanning
- [ ] Custom port ranges

## Project structure

```
NetScout/
├── Program.cs          # Argument parsing and command routing
└── Commands/
    ├── PingCommand.cs  # ICMP ping
    ├── ScanCommand.cs  # TCP port scanner
    └── DnsCommand.cs   # Forward and reverse DNS lookup
```

## Legal notice

Only scan systems you own or have explicit permission to test. Unauthorized port scanning may be illegal and can violate your ISP's terms of service. For safe testing use `127.0.0.1`, your own home network, or `scanme.nmap.org`.

The author is not responsible for any misuse of this tool.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.