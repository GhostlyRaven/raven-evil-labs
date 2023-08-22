using System;
using System.Collections.Generic;

// ReSharper disable All

namespace Factory
{
    public static class Program
    {
        public static void Main()
        {
            Developer developer1 = new PanelDeveloper("ООО КирпичСтрой");
            House house1 = developer1.Create("Монолит 1");
            house1.Print();

            Developer developer2 = new WoodDeveloper("ООО Частный застройщик");
            House house2 = developer2.Create("Избища 1");
            house2.Print();

            Console.WriteLine();

            StaticDeveloper.FirstCreate(0, "Монолит 2").Print();
            StaticDeveloper.FirstCreate(1, "Избища 2").Print();

            Console.WriteLine();

            StaticDeveloper.SecondCreate(0).Invoke("Монолит 3").Print();
            StaticDeveloper.SecondCreate(1).Invoke("Избища 3").Print();

            Console.ReadKey();
        }
    }

    public abstract class Developer
    {
        protected string Name;

        public Developer(string name)
        {
            Name = name;
        }

        public abstract House Create(string houseName);
    }

    public class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name) { }

        public override House Create(string houseName)
        {
            return new PanelHouse(houseName, Name);
        }
    }

    public class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name) { }

        public override House Create(string houseName)
        {
            return new WoodHouse(houseName, Name);
        }
    }

    public abstract class House
    {
        protected string Name;
        protected string DeveloperName;

        protected House(string name, string developerName)
        {
            Name = name;
            DeveloperName = developerName;
        }

        public abstract void Print();
    }

    public class PanelHouse : House
    {
        public PanelHouse(string name, string developerName) : base(name, developerName) { }

        public override void Print()
        {
            Console.WriteLine($"Панельный дом {Name} построен {DeveloperName}");
        }
    }

    public class WoodHouse : House
    {
        public WoodHouse(string name, string developerName) : base(name, developerName) { }

        public override void Print()
        {
            Console.WriteLine($"Деревянный дом {Name} построен {DeveloperName}");
        }
    }

    public static class StaticDeveloper
    {
        private static Dictionary<int, Func<string, House>> _houses = new()
        {
            { 0, (houseName) => new PanelHouse(houseName, "ООО КирпичСтрой") },
            { 1, (houseName) => new WoodHouse(houseName, "ООО Частный застройщик") }
        };

        public static House FirstCreate(int number, string houseName)
        {
            return number switch
            {
                0 => new PanelHouse(houseName, "ООО КирпичСтрой"),
                1 => new WoodHouse(houseName, "ООО Частный застройщик"),
                _ => throw new Exception("Нет такого дома!!!")
            };
        }

        public static Func<string, House> SecondCreate(int number)
        {
            return _houses[number];
        }
    }
}
