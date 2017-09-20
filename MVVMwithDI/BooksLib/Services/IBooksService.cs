using System.Collections.Generic;
using MySharedLib.Models;
using System.ComponentModel;

namespace MySharedLib.Services
{
    public interface IBooksService : INotifyPropertyChanged
    {
        Book CurrentBook { get; set; }

        void AddBook(Book book);
        IEnumerable<Book> GetBooks();
    }
}