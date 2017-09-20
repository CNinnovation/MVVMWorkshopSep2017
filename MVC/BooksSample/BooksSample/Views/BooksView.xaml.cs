using BooksSample.Models;
using BooksSample.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BooksSample.Views
{
    /// <summary>
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {

        public BooksView()
        {
            InitializeComponent();

        }

        private void OnGetBooks(object sender, RoutedEventArgs e)
        {
            listBooks.Items.Clear();

            var books = BooksService.Instance.GetBooks().ToList();

            foreach (var b in books)
            {
                listBooks.Items.Add(b);
            }
        }

        private void OnSelectBook(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            var book = e.AddedItems[0] as Book;
            if (book != null)
            {
                BooksService.Instance.CurrentBook = book;   
            }
        }
    }
}
