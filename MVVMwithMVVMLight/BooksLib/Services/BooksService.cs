using GalaSoft.MvvmLight;
using MySharedLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace MySharedLib.Services
{
    public class BooksService : ObservableObject, IBooksService
    {
        private List<Book> _books;

        public BooksService()
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
            get => _currentBook;
            set => Set(ref _currentBook, value);
        }

        public void AddBook(Book book)
        {

        }
    }
}
