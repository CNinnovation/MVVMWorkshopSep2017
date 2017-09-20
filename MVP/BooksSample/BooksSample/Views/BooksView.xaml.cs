using BooksSample.Models;
using BooksSample.Presenters;
using System.Windows;
using System.Windows.Controls;

namespace BooksSample.Views
{
    /// <summary>
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : UserControl, IBooksView
    {
        private BooksViewPresenter _booksViewPresenter;

        public BooksView()
        {
            InitializeComponent();
            _booksViewPresenter = new BooksViewPresenter(this);
        }

        public ListBox BooksList => listBooks;


        private void OnGetBooks(object sender, RoutedEventArgs e)
        {
            _booksViewPresenter.SetBooks();
        }

        private void OnSelectBook(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            var book = e.AddedItems[0] as Book;

            _booksViewPresenter.SetCurrentBook(book);
        }
    }
}
