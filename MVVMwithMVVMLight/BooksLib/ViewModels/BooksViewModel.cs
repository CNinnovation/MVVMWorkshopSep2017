using BooksLib.Services;
using GalaSoft.MvvmLight.Command;
using MySharedLib.Models;
using MySharedLib.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MySharedLib.ViewModels
{
    public class BooksViewModel
    {
        private readonly IBooksService _booksService;
        private readonly IDialogService _dialogService;
        
        public BooksViewModel(IBooksService booksService, IDialogService dialogService)
        {
            _booksService = booksService;
            _dialogService = dialogService;
            Books = new ObservableCollection<Book>();

            GetBooksCommand = new RelayCommand(OnGetBooks);
            ShowMessageCommand = new RelayCommand(OnShowMessageAsync);
        }
        public IList<Book> Books { get;  }

        public ICommand GetBooksCommand { get; }
        public ICommand ShowMessageCommand { get; }

        public void OnGetBooks()
        {
            Books.Clear();

            var books = _booksService.GetBooks();

            foreach (var b in books)
            {
                Books.Add(b);
            }
        }

        public async void OnShowMessageAsync()
        {
            await _dialogService.ShowMessageAsync("hello from MVVM");
        }


        public Book SelectedBook
        {
            get => _booksService.CurrentBook;
            set => _booksService.CurrentBook = value;
        }
    }
}
