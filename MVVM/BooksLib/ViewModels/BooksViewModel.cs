using MySharedLib.Models;
using MySharedLib.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheBestMVVMFrameworkInTown;

namespace MySharedLib.ViewModels
{
    public class BooksViewModel
    {
        private BooksService _booksService;
        public BooksViewModel()
        {
            _booksService = BooksService.Instance;
            Books = new ObservableCollection<Book>();

            GetBooksCommand = new DelegateCommand(OnGetBooks);
        }
        public IList<Book> Books { get;  }

        public ICommand GetBooksCommand { get; }

        public void OnGetBooks()
        {
            Books.Clear();

            var books = _booksService.GetBooks();

            foreach (var b in books)
            {
                Books.Add(b);
            }
        }


        public Book SelectedBook
        {
            get { return _booksService.CurrentBook; }
            set { _booksService.CurrentBook = value; }
        }

    }
}
