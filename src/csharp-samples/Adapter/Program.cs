using System;

// ReSharper disable All

namespace Adapter
{
    public static class Program
    {
        public static void Main()
        {
            Driver driver = new Driver("Ивана");

            Car auto = new Car();

            driver.Travel(auto);

            CamelToTransportAdapter camelTransport = new Camel();

            driver.Travel(camelTransport);

            Console.ReadKey();
        }
    }

    public interface ITransport
    {
        void Drive(string driverName);
    }

    public interface IAnimal
    {
        void Move(string driverName);
    }

    public class Car : ITransport
    {
        public void Drive(string driverName)
        {
            Console.WriteLine($"Машина едет по дороге под управлением {driverName}!!!");
        }
    }

    public class Camel : IAnimal
    {
        public void Move(string driverName)
        {
            Console.WriteLine($"Верблюд идет по пескам пустыни под управлением {driverName}!!!");
        }
    }

    public class Driver
    {
        private readonly string _name;

        public Driver(string name)
        {
            _name = name;
        }

        public void Travel(ITransport transport)
        {
            transport.Drive(_name);
        }
    }

    public class CamelToTransportAdapter : ITransport
    {
        private readonly Camel _camel;

        public CamelToTransportAdapter(Camel camel)
        {
            _camel = camel;
        }

        public void Drive(string driverName)
        {
            _camel.Move(driverName);
        }

        public static implicit operator CamelToTransportAdapter(Camel camel)
        {
            return new CamelToTransportAdapter(camel);
        }
    }
}
