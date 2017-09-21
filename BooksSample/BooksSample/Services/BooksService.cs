using BooksSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSample.Services
{
    public class BooksService : IBooksService
    {
        private IEnumerable<Book> GetSampleBooks()
        {
            var b1 = new Book(1, "Professional C# 5.0", "Wrox Press", "Christian Nagel", "Jay Glynn", "Morgan Skinner");
            var b2 = new Book(2, "Enterprise Services", "AWL", "Christian Nagel");
            var b3 = new Book(3, "Beginning Visual C#", "Wrox Press", "Karli Watson", "Christian Nagel");
            return new List<Book>()
            {
                b1, b2, b3
            };
        }
        //public IEnumerable<Book> GetBooks() => Enumerable.Range(0, 10)
        //    .Select(x => new Book { BookId = x, Title = $"title {x}", Publisher = "Sample Pub" })
        //    .ToList();



        public IEnumerable<Book> GetBooks() => GetSampleBooks();

    }
}
