using BooksSample.Models;
using BooksSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSample.Presenters
{
    public enum EditMode
    {
        View,
        CreateNew,
        Edit
    }

    public class BookViewPresenter
    {
        private readonly IBookView _bookView;
        private readonly BooksService _booksService = BooksService.Instance;
        private EditMode _currentMode;
        private Book _newBook;

        public BookViewPresenter(IBookView bookView)
        {
            _bookView = bookView;

            SetMode(EditMode.View);

            _booksService.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "CurrentBook")
                {
                    SetBook(_booksService.CurrentBook);
                }
            };
        }

        private void SetMode(EditMode mode)
        {
            switch (mode)
            {
                case EditMode.View:
                    _bookView.CreateButton.IsEnabled = true;
                    _bookView.CancelButton.IsEnabled = false;
                    _bookView.EditButton.IsEnabled = true;
                    _bookView.SaveButton.IsEnabled = false;
                    _bookView.TextTitle.IsEnabled = false;
                    _bookView.TextPublisher.IsEnabled = false;
                    break;
                case EditMode.CreateNew:
                case EditMode.Edit:
                    _bookView.CreateButton.IsEnabled = false;
                    _bookView.CancelButton.IsEnabled = true;
                    _bookView.EditButton.IsEnabled = false;
                    _bookView.SaveButton.IsEnabled = true;
                    _bookView.TextTitle.IsEnabled = true;
                    _bookView.TextPublisher.IsEnabled = true;
                    break;
                default:
                    break;
            }
            _currentMode = mode;
        }

        public void CreateBook()
        {
            SetMode(EditMode.CreateNew);
            _newBook = new Book();
            _newBook.BookId = _booksService.GetNextBookId();

            SetBook(_newBook);
        }

        private void SetBook(Book b)
        {
            _bookView.TextId.Text = b.BookId.ToString();
            _bookView.TextTitle.Text = b.Title;
            _bookView.TextPublisher.Text = b.Publisher;
        }

        public void SaveBook()
        {
            if (_currentMode == EditMode.Edit)
            {
                _booksService.CurrentBook.Title = _bookView.TextTitle.Text;
                _booksService.CurrentBook.Publisher = _bookView.TextPublisher.Text;
            }
            else if (_currentMode == EditMode.CreateNew)
            {
                _newBook.Title = _bookView.TextTitle.Text;
                _newBook.Publisher = _bookView.TextPublisher.Text;
                _booksService.AddBook(_newBook);
            }
            SetMode(EditMode.View);
        }

        public void CancelEdit()
        {
            SetMode(EditMode.View);
            _newBook = null;
        }

        public void SetEdit()
        {
            SetMode(EditMode.Edit);
        }
    }
}
