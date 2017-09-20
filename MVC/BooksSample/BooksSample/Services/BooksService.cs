using BooksSample.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BooksSample.Services
{
    public class BooksService : INotifyPropertyChanged
    {
        private IList<Book> _books;

        private BooksService()
        {
            _books = Enumerable.Range(1, 10)
                .Select(i => new Book { BookId = i, Title = $"Sample{i}", Publisher = "Sample Publisher" })
                .ToList();

            CurrentBook = _books.First();
        }

        private static BooksService _booksService;

        public event PropertyChangedEventHandler PropertyChanged;

        public static BooksService Instance => _booksService ?? (_booksService = new BooksService());

        public IEnumerable<Book> GetBooks() => _books;

        private Book _currentBook;
        public Book CurrentBook
        {
            get { return _currentBook; }
            set
            {
                if (!EqualityComparer<Book>.Default.Equals(_currentBook, value))
                {
                    _currentBook = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentBook)));
                }
            }
        }

        public int GetNextBookId() => _books.Max(b => b.BookId) + 1;

        public void AddBook(Book b)
        {
            _books.Add(b);
        }
    }
}
