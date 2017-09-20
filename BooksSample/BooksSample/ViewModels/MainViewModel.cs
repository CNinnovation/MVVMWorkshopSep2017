using BooksSample.Models;
using BooksSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheBestMVVMFrameworkInTown;

namespace BooksSample.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            GetBooksCommand = new RelayCommand(OnLoadBooks);
        }

        public void OnLoadBooks()
        {
            Books = BooksService.Instance.GetBooks();
        }

        public IEnumerable<Book> Books { get; set; }

        public ICommand GetBooksCommand { get; }
    }
}
