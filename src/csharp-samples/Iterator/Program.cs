using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable All

namespace Iterator
{
    public static class Program
    {
        public static void Main()
        {
            Library library = new Book[]
            {
                new Book
                {
                    Name = "Война и мир"
                },
                new Book
                {
                    Name = "Преступление и наказание"
                },
                new Book
                {
                    Name = "Евгений Онегин"
                },
            };

            foreach (Book book in library)
            {
                Console.WriteLine($"Book name: {book.Name}");
            }

            Console.WriteLine();

            IEnumerator<Book> enumerator = library.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine($"Book name: {enumerator.Current.Name}");
            }

            enumerator.Reset();

            enumerator.Dispose();

            Console.ReadKey();
        }
    }

    public class Book
    {
        public string Name { get; set; }
    }

    public class Library : IEnumerable<Book>
    {
        private readonly Book[] _books;

        public Library(Book[] books)
        {
            _books = books;
        }

        public static implicit operator Library(Book[] books)
        {
            return new Library(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(_books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct LibraryIterator : IEnumerator<Book>
        {
            private int _index;
            private Book _current;

            private readonly Book[] _books;

            public LibraryIterator(Book[] books)
            {
                _index = 0;
                _books = books;
                _current = default;
            }

            public bool MoveNext()
            {
                Book[] localBooks = _books;

                if (_index < localBooks.Length)
                {
                    _current = localBooks[_index];
                    _index++;

                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _index = 0;
                _current = default;
            }

            public Book Current => _current;

            object IEnumerator.Current => _current;

            public void Dispose() { }
        }
    }
}
