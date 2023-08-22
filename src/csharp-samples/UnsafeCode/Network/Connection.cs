using System.Net;
using System.Diagnostics;

// ReSharper disable All

namespace UnsafeCode.Networks
{
    public sealed class Connection
    {
        public Process Process { get; set; } = default!;

        public IPAddress SourceAddress { get; set; } = IPAddress.None;

        public IPAddress DestinationAddress { get; set; } = IPAddress.None;

        public int SourcePort { get; set; } = 0;

        public int DestinationPort { get; set; } = 0;

        public MibTcpState State { get; set; } = MibTcpState.None;

        public override string ToString()
        {
            return string.Format("PID: {0} | {1} | Source address: {2} | Source port: {3} | Destination address: {4} | Destination port: {5} | State: {6}",
                Process.Id, Process.ProcessName, SourceAddress, SourcePort, DestinationAddress, DestinationPort, State);
        }
    }
}
