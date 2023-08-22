using System;
using System.Linq;
using System.Collections.Generic;

// ReSharper disable All

namespace Proxy
{
    public static class Program
    {
        public static void Main()
        {
            IBookStore bookStore = new BookStoreProxy();

            Page page1 = bookStore.GetPage(1);

            Console.WriteLine(page1.Text);

            Page page2 = bookStore.GetPage(2);

            Console.WriteLine(page2.Text);

            Page page3 = bookStore.GetPage(1);

            Console.WriteLine(page3.Text);

            Console.ReadKey();
        }
    }

    public class Page
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }

    public interface IBookStore
    {
        Page GetPage(int number);
    }

    public class BookStore : IBookStore
    {
        private readonly List<Page> _pages;

        public BookStore()
        {
            _pages = new List<Page>
            {
                new ()
                {
                    Number = 1,
                    Text = "Какой-то рандомный текст."
                },
                new ()
                {
                    Number = 2,
                    Text = "Еще немного рандомного текста."
                },
                new ()
                {
                    Number = 3,
                    Text = "Он все еще не кончился."
                },
                new ()
                {
                    Number = 4,
                    Text = "Наконец-то он закончился."
                }
            };
        }

        public Page GetPage(int number)
        {
            return _pages.FirstOrDefault(page => page.Number == number);
        }
    }

    public class BookStoreProxy : IBookStore
    {
        private readonly List<Page> _pages;
        private readonly BookStore _bookStore;

        public BookStoreProxy()
        {
            _pages = new List<Page>();
            _bookStore = new BookStore();
        }

        public Page GetPage(int number)
        {
            Page page = _pages.FirstOrDefault(page => page.Number == number);

            if (page is null)
            {
                page = _bookStore.GetPage(number);

                if (page is not null)
                {
                    _pages.Add(page);
                }
            }

            return page;
        }
    }
}
