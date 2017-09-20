using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSample.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(int bookId, string title, string publisher, params string[] authors)
        {
            BookId = bookId;
            Title = title;
            Publisher = publisher;
            Authors = new List<string>(authors);
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public IEnumerable<string> Authors { get;  }

        public override string ToString() => Title;

    }
}
