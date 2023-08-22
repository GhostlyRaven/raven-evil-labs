// ReSharper disable All

namespace UnsafeCode.Networks
{
    public enum Af
    {
        Inet = 2,
        Inet6 = 23
    }

    public enum TcpTableClass
    {
        TcpTableBasicListener,
        TcpTableBasicConnections,
        TcpTableBasicAll,
        TcpTableOwnerPidListener,
        TcpTableOwnerPidConnections,
        TcpTableOwnerPidAll,
        TcpTableOwnerModuleListener,
        TcpTableOwnerModuleConnections,
        TcpTableOwnerModuleAll
    }

    public enum UdpTableClass
    {
        UdpTableBasic,
        UdpTableOwnerPid,
        UdpTableOwnerModule
    }

    public enum MibTcpState
    {
        None = 0,
        Closed = 1,
        Listening = 2,
        SynSent = 3,
        Established = 5,
        FinWait1 = 6,
        FinWait2 = 7,
        CloseWait = 8,
        Closing = 9,
        LastAck = 10,
        TimeWait = 11,
        DeleteTcp = 12
    }
}
