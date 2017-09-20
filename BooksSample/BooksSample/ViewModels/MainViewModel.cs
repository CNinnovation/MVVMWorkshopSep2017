using BooksSample.Models;
using BooksSample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheBestMVVMFrameworkInTown;

namespace BooksSample.ViewModels
{
    public class MainViewModel
    {

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public MainViewModel()
        {
            GetBooksCommand = new RelayCommand(OnLoadBooks);
            ChangeBookCommand = new RelayCommand(OnChangeBook);
        }

        private void OnChangeBook()
        {
            SelectedBook.Title = "a new title";
        }

        public void OnLoadBooks()
        {
            var books = BooksService.Instance.GetBooks();
            foreach (var book in books)
            {
                _books.Add(book);
            }
        }

        public IEnumerable<Book> Books => _books;

        public ICommand GetBooksCommand { get; }
        public ICommand ChangeBookCommand { get; }

        private Book _selectedBook;

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set { _selectedBook = value; }
        }

    }
}
