using System;

// ReSharper disable All

namespace Singleton
{
    public static class Program
    {
        public static void Main()
        {
            Singleton.Instance.Print();
            ThreadSingleton.Instance.Print();
            LazySingleton.Instance.Print();

            Singleton.Instance.Print();
            ThreadSingleton.Instance.Print();
            LazySingleton.Instance.Print();

            Console.ReadKey();
        }
    }

    public sealed class Singleton
    {
        private int _counter = 0;

        private static Singleton _instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }

        public void Print()
        {
            _counter++;

            Console.WriteLine($"{nameof(Singleton)}: {_counter}");
        }
    }

    public sealed class ThreadSingleton
    {
        private int _counter = 0;

        private static volatile ThreadSingleton _instance;
        private static readonly object _syncRoot = new();

        private ThreadSingleton() { }

        public static ThreadSingleton Instance
        {
            get
            {
                if (_instance is null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance is null)
                        {
                            _instance = new ThreadSingleton();
                        }
                    }
                }

                return _instance;
            }
        }

        public void Print()
        {
            _counter++;

            Console.WriteLine($"{nameof(ThreadSingleton)}: {_counter}");
        }
    }

    public sealed class LazySingleton
    {
        private int _counter = 0;

        private static readonly Lazy<LazySingleton> _instance = new(() => new LazySingleton());

        private LazySingleton() { }

        public static LazySingleton Instance => _instance.Value;

        public void Print()
        {
            _counter++;

            Console.WriteLine($"{nameof(LazySingleton)}: {_counter}");
        }
    }
}
