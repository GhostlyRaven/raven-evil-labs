using UnsafeCode.Networks;

namespace UnsafeCode
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Connections:");

            foreach (Connection connection in IpHlpApi.GetNetworkConnections())
            {
                Console.WriteLine(connection);
            }

            Console.ReadKey();
        }
    }
}
