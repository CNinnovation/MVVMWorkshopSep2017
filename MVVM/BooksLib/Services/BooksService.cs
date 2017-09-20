using MySharedLib.Models;
using System.Collections.Generic;
using System.Linq;
using TheBestMVVMFrameworkInTown;

namespace MySharedLib.Services
{
    public class BooksService : BindableBase
    {
        private List<Book> _books;

        private static BooksService _instance;

        // Singleton pattern
        public static BooksService Instance => _instance ?? (_instance = new BooksService());
        private BooksService()
        {
            var books = Enumerable.Range(1, 10)
               .Select(x =>
                   new Book
                   {
                       BookId = x,
                       Title = $"sample {x}",
                       Publisher = "sample pub",
                       Authors = Enumerable.Range(1, 3)
                        .Select(x1 => $"author {x1}").ToArray()
                   });

            _books = new List<Book>(books);
            CurrentBook = _books.First();
        }

        public IEnumerable<Book> GetBooks() => _books;

        private Book _currentBook;
        public Book CurrentBook
        {
            get { return _currentBook; }
            set
            {
                SetProperty(ref _currentBook, value);
                //if (_currentBook != value)
                //{
                //    _currentBook = value;
                //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentBook"));

                //    //PropertyChangedEventHandler handler = PropertyChanged;
                //    //if (handler != null)
                //    //{
                //    //    handler(this, new PropertyChangedEventArgs("CurrentBook"));
                //    //}
                //}
            }
        }

        public void AddBook(Book book)
        {

        }
    }
}
