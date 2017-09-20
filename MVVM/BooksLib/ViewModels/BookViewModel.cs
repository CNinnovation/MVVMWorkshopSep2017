using MySharedLib.Models;
using MySharedLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestMVVMFrameworkInTown;

namespace MySharedLib.ViewModels
{
    public class BookViewModel : BindableBase
    {
        private BooksService _booksService;
        public BookViewModel()
        {
            _booksService = BooksService.Instance;
            _booksService.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "CurrentBook")
                {
                    base.RaisePropertyChanged(nameof(CurrentBook));
                }
            };
        }

        public Book CurrentBook
        {
            get { return _booksService.CurrentBook; }
        }
    }
}
