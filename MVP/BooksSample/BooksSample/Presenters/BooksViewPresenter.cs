using BooksSample.Models;
using BooksSample.Services;
using BooksSample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSample.Presenters
{
    public class BooksViewPresenter
    {
        private readonly IBooksView _booksView;
        public BooksViewPresenter(IBooksView booksView)
        {
            _booksView = booksView;
        }

        public void SetBooks()
        {
            _booksView.BooksList.Items.Clear();

            var books = BooksService.Instance.GetBooks().ToList();

            foreach (var b in books)
            {
                _booksView.BooksList.Items.Add(b);
            }
        }

        public void SetCurrentBook(Book book)
        {
            if (book != null)
            {
                BooksService.Instance.CurrentBook = book;
            }
        }
    }
}
