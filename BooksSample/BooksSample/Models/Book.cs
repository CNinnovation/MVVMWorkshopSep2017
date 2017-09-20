using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestMVVMFrameworkInTown;

namespace BooksSample.Models
{
    public class Book : BindableBase
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
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _publisher;

        public string Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }


        public IEnumerable<string> Authors { get; }

        public override string ToString() => Title;

    }
}
