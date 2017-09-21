using GalaSoft.MvvmLight;
using MySharedLib.Models;
using MySharedLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySharedLib.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        private IBooksService _booksService;
        public BookViewModel(IBooksService booksService)
        {
            _booksService = booksService;

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
            get => _booksService.CurrentBook;
        }
    }
}
