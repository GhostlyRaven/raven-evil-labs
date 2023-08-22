using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;

// ReSharper disable All

namespace UnsafeCode.Networks
{
    public static class IpHlpApi
    {
        //IPHLPAPI_DLL_LINKAGE DWORD GetExtendedTcpTable([out] PVOID pTcpTable, [in, out] PDWORD pdwSize, [in] BOOL bOrder, [in] ULONG ulAf, [in] TCP_TABLE_CLASS TableClass, [in] ULONG Reserved);
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedTcpTable(nint tcpTablePtr, ref int size, bool order, Af ulAf, TcpTableClass tableClass, uint reserved = 0);

        //IPHLPAPI_DLL_LINKAGE DWORD GetExtendedUdpTable([out] PVOID pUdpTable, [in, out] PDWORD pdwSize, [in] BOOL bOrder, [in] ULONG ulAf, [in] UDP_TABLE_CLASS TableClass, [in] ULONG Reserved);
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedUdpTable(nint udpTablePtr, ref int size, bool order, Af ulAf, UdpTableClass tableClass, uint reserved = 0);

        [StructLayout(LayoutKind.Sequential)]
        private struct ConnectionTable
        {
            public uint Length { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MibTcpRowOwnerPid
        {
            public MibTcpState State { get; }

            public uint LocalAddress { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LocalPort { get; }

            public uint RemoteAddress { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] RemotePort { get; }

            public int OwningPid { get; }

            public void Deconstruct(out MibTcpState state, out uint localAddress, out byte[] localPort, out uint remoteAddress, out byte[] remotePort, out int owningPid)
            {
                state = State;
                localAddress = LocalAddress;
                localPort = LocalPort;
                remoteAddress = RemoteAddress;
                remotePort = RemotePort;
                owningPid = OwningPid;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MibTcp6RowOwnerPid
        {
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] LocalAddress { get; }

            public uint LocalScopeId { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LocalPort { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] RemoteAddress { get; }

            public uint RemoteScopeId { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] RemotePort { get; }

            public MibTcpState State { get; }

            public int OwningPid { get; }

            public void Deconstruct(out MibTcpState state, out byte[] localAddress, out uint localScopeId, out byte[] localPort, out byte[] remoteAddress, out uint remoteScopeId, out byte[] remotePort, out int owningPid)
            {
                state = State;
                localAddress = LocalAddress;
                localScopeId = LocalScopeId;
                localPort = LocalPort;
                remoteAddress = RemoteAddress;
                remoteScopeId = RemoteScopeId;
                remotePort = RemotePort;
                owningPid = OwningPid;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MibUdpRowOwnerPid
        {
            public uint LocalAddress { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LocalPort { get; }

            public int OwningPid { get; }

            public void Deconstruct(out uint localAddress, out byte[] localPort, out int owningPid)
            {
                localAddress = LocalAddress;
                localPort = LocalPort;
                owningPid = OwningPid;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MibUdp6RowOwnerPid
        {
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] LocalAddress { get; }

            public uint LocalScopeId { get; }

            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LocalPort { get; }

            public int OwningPid { get; }

            public void Deconstruct(out byte[] localAddress, out uint localScopeId, out byte[] localPort, out int owningPid)
            {
                localAddress = LocalAddress;
                localScopeId = LocalScopeId;
                localPort = LocalPort;
                owningPid = OwningPid;
            }
        }

        private static Connection[] GetTcpConnections(TcpTableClass tableClass)
        {
            int bufferSize = 0;
            int nextRowOffset = Marshal.SizeOf<MibTcpRowOwnerPid>();

            _ = GetExtendedTcpTable(IntPtr.Zero, ref bufferSize, true, Af.Inet, tableClass);

            nint tcpTablePtr = Marshal.AllocHGlobal(bufferSize);

            try
            {
                _ = GetExtendedTcpTable(tcpTablePtr, ref bufferSize, true, Af.Inet, tableClass);

                uint length = Marshal.PtrToStructure<ConnectionTable>(tcpTablePtr).Length;

                Connection[] buffer = new Connection[length];

                nint tableRowPtr = tcpTablePtr + 4;

                for (int row = 0; row < length; row++)
                {
                    (MibTcpState state, uint localAddress, byte[] localPort, uint remoteAddress, byte[] remotePort, int owningPid) = Marshal.PtrToStructure<MibTcpRowOwnerPid>(tableRowPtr);

                    buffer[row] = new Connection
                    {
                        Process = Process.GetProcessById(owningPid),
                        SourceAddress = new IPAddress(localAddress),
                        DestinationAddress = new IPAddress(remoteAddress),
                        SourcePort = BitConverter.ToUInt16(new[]
                        {
                            localPort[1],
                            localPort[0]
                        }, 0),
                        DestinationPort = BitConverter.ToUInt16(new[]
                        {
                            remotePort[1],
                            remotePort[0]
                        }, 0),
                        State = state
                    };

                    tableRowPtr += nextRowOffset;
                }

                return buffer;
            }
            catch (Exception)
            {
                return Array.Empty<Connection>();
            }
            finally
            {
                Marshal.FreeHGlobal(tcpTablePtr);
            }
        }

        private static Connection[] GetTcp6Connections(TcpTableClass tableClass)
        {
            int bufferSize = 0;
            int nextRowOffset = Marshal.SizeOf<MibTcp6RowOwnerPid>();

            _ = GetExtendedTcpTable(IntPtr.Zero, ref bufferSize, true, Af.Inet6, tableClass);

            nint tcpTablePtr = Marshal.AllocHGlobal(bufferSize);

            try
            {
                _ = GetExtendedTcpTable(tcpTablePtr, ref bufferSize, true, Af.Inet6, tableClass);

                uint length = Marshal.PtrToStructure<ConnectionTable>(tcpTablePtr).Length;

                Connection[] buffer = new Connection[length];

                nint tableRowPtr = tcpTablePtr + 4;

                for (int row = 0; row < length; row++)
                {
                    (MibTcpState state, byte[] localAddress, uint localScopeId, byte[] localPort, byte[] remoteAddress, uint remoteScopeId, byte[] remotePort, int owningPid) = Marshal.PtrToStructure<MibTcp6RowOwnerPid>(tableRowPtr);

                    buffer[row] = new Connection
                    {
                        Process = Process.GetProcessById(owningPid),
                        SourceAddress = new IPAddress(localAddress, localScopeId),
                        DestinationAddress = new IPAddress(remoteAddress, remoteScopeId),
                        SourcePort = BitConverter.ToUInt16(new[]
                        {
                                localPort[1],
                                localPort[0]
                            }, 0),
                        DestinationPort = BitConverter.ToUInt16(new[]
                        {
                                remotePort[1],
                                remotePort[0]
                            }, 0),
                        State = state
                    };

                    tableRowPtr += nextRowOffset;
                }

                return buffer;
            }
            catch (Exception)
            {
                return Array.Empty<Connection>();
            }
            finally
            {
                Marshal.FreeHGlobal(tcpTablePtr);
            }
        }

        private static Connection[] GetUdpConnections(UdpTableClass tableClass)
        {
            int bufferSize = 0;
            int nextRowOffset = Marshal.SizeOf<MibUdpRowOwnerPid>();

            _ = GetExtendedUdpTable(IntPtr.Zero, ref bufferSize, true, Af.Inet, tableClass);

            nint udpTablePtr = Marshal.AllocHGlobal(bufferSize);

            try
            {
                _ = GetExtendedUdpTable(udpTablePtr, ref bufferSize, true, Af.Inet, tableClass);

                uint length = Marshal.PtrToStructure<ConnectionTable>(udpTablePtr).Length;

                Connection[] buffer = new Connection[length];

                nint tableRowPtr = udpTablePtr + 4;

                for (int row = 0; row < length; row++)
                {
                    (uint localAddress, byte[] localPort, int owningPid) = Marshal.PtrToStructure<MibUdpRowOwnerPid>(tableRowPtr);

                    buffer[row] = new Connection
                    {
                        Process = Process.GetProcessById(owningPid),
                        SourceAddress = new IPAddress(localAddress),
                        DestinationAddress = IPAddress.None,
                        SourcePort = BitConverter.ToUInt16(new[]
                        {
                            localPort[1],
                            localPort[0]
                        }, 0),
                        DestinationPort = default,
                        State = MibTcpState.None
                    };

                    tableRowPtr += nextRowOffset;
                }

                return buffer;
            }
            catch (Exception)
            {
                return Array.Empty<Connection>();
            }
            finally
            {
                Marshal.FreeHGlobal(udpTablePtr);
            }
        }

        private static Connection[] GetUdp6Connections(UdpTableClass tableClass)
        {
            int bufferSize = 0;
            int nextRowOffset = Marshal.SizeOf<MibUdp6RowOwnerPid>();

            _ = GetExtendedUdpTable(IntPtr.Zero, ref bufferSize, true, Af.Inet6, tableClass);

            nint udpTablePtr = Marshal.AllocHGlobal(bufferSize);

            try
            {
                _ = GetExtendedUdpTable(udpTablePtr, ref bufferSize, true, Af.Inet6, tableClass);

                uint length = Marshal.PtrToStructure<ConnectionTable>(udpTablePtr).Length;

                Connection[] buffer = new Connection[length];

                nint tableRowPtr = udpTablePtr + 4;

                for (int row = 0; row < length; row++)
                {
                    (byte[] localAddress, uint localScopeId, byte[] localPort, int owningPid) = Marshal.PtrToStructure<MibUdp6RowOwnerPid>(tableRowPtr);

                    buffer[row] = new Connection
                    {
                        Process = Process.GetProcessById(owningPid),
                        SourceAddress = new IPAddress(localAddress, localScopeId),
                        DestinationAddress = IPAddress.None,
                        SourcePort = BitConverter.ToUInt16(new[]
                        {
                            localPort[1],
                            localPort[0]
                        }, 0),
                        DestinationPort = default,
                        State = MibTcpState.None
                    };

                    tableRowPtr += nextRowOffset;
                }

                return buffer;
            }
            catch (Exception)
            {
                return Array.Empty<Connection>();
            }
            finally
            {
                Marshal.FreeHGlobal(udpTablePtr);
            }
        }

        public static IEnumerable<Connection> GetNetworkConnections()
        {
            Connection[] tcp = GetTcpConnections(TcpTableClass.TcpTableOwnerPidAll);
            Connection[] tcp6 = GetTcp6Connections(TcpTableClass.TcpTableOwnerPidAll);

            Connection[] udp = GetUdpConnections(UdpTableClass.UdpTableOwnerPid);
            Connection[] udp6 = GetUdp6Connections(UdpTableClass.UdpTableOwnerPid);

            return tcp.Concat(tcp6).Concat(udp).Concat(udp6).OrderBy(connection => connection.Process.ProcessName);
        }
    }
}
