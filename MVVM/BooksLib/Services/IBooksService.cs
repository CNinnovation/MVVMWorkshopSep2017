using System.Collections.Generic;
using MySharedLib.Models;

namespace MySharedLib.Services
{
    public interface IBooksService
    {
        Book CurrentBook { get; set; }

        void AddBook(Book book);
        IEnumerable<Book> GetBooks();
    }
}