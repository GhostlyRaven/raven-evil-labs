using System;

// ReSharper disable All

namespace Decorator
{
    public static class Program
    {
        public static void Main()
        {
            Pizza pizza1 = new ItalianPizza(10);

            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}$", pizza1.GetCost());
            Console.WriteLine();

            pizza1 = new TomatoPizza(pizza1, 5); // итальянская пицца с томатами

            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}$", pizza1.GetCost());
            Console.WriteLine();

            Pizza pizza2 = new ItalianPizza(10);

            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}$", pizza2.GetCost());
            Console.WriteLine();

            pizza2 = new CheesePizza(pizza2, 10); // итальянская пиццы с сыром

            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}$", pizza2.GetCost());
            Console.WriteLine();

            Pizza pizza3 = new BulgerianPizza(12);

            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}$", pizza3.GetCost());
            Console.WriteLine();

            pizza3 = new TomatoPizza(pizza3, 5); // болгарская пиццы с томатами

            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}$", pizza3.GetCost());
            Console.WriteLine();

            pizza3 = new CheesePizza(pizza3, 10); // болгарская пиццы с томатами и сыром

            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}$", pizza3.GetCost());
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public abstract class Pizza
    {
        public Pizza(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract int GetCost();
    }

    public abstract class PizzaDecorator : Pizza
    {
        protected readonly Pizza Pizza;

        public PizzaDecorator(string name, Pizza pizza) : base(name)
        {
            Pizza = pizza;
        }
    }

    public class ItalianPizza : Pizza
    {
        private readonly int _cost;

        public ItalianPizza(int cost) : base("Итальянская пицца")
        {
            _cost = cost;
        }

        public override int GetCost()
        {
            return _cost;
        }
    }

    public class BulgerianPizza : Pizza
    {
        private readonly int _cost;

        public BulgerianPizza(int cost) : base("Болгарская пицца")
        {
            _cost = cost;
        }

        public override int GetCost()
        {
            return _cost;
        }
    }

    public class TomatoPizza : PizzaDecorator
    {
        private readonly int _cost;

        public TomatoPizza(Pizza pizza, int cost) : base(pizza.Name + ", с томатами", pizza)
        {
            _cost = cost;
        }

        public override int GetCost()
        {
            return Pizza.GetCost() + _cost;
        }
    }

    public class CheesePizza : PizzaDecorator
    {
        private readonly int _cost;

        public CheesePizza(Pizza pizza, int cost) : base(pizza.Name + ", с сыром", pizza)
        {
            _cost = cost;
        }

        public override int GetCost()
        {
            return Pizza.GetCost() + _cost;
        }
    }
}
