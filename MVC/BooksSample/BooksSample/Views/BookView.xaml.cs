using BooksSample.Models;
using BooksSample.Services;
using System.Windows;
using System.Windows.Controls;

namespace BooksSample.Views
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView : UserControl
    {
        private BooksService _booksService = BooksService.Instance;
        private Book _newBook;
        private EditMode _currentMode;

        public BookView()
        {
            InitializeComponent();
            SetMode(EditMode.View);

            _booksService.PropertyChanged += (sender, e) =>
            {   
                if (e.PropertyName == "CurrentBook")
                {
                    SetBook(_booksService.CurrentBook);
                }
            };
        }

        private void OnCreate(object sender, RoutedEventArgs e)
        {
            SetMode(EditMode.CreateNew);
            _newBook = new Book();
            _newBook.BookId = _booksService.GetNextBookId(); 

            SetBook(_newBook);
        }

        private void SetBook(Book b)
        {
            textId.Text = b.BookId.ToString();
            textTitle.Text = b.Title;
            textPublisher.Text = b.Publisher;
        }

        private void SetMode(EditMode mode)
        {
            switch (mode)
            {
                case EditMode.View:
                    createButton.IsEnabled = true;
                    cancelButton.IsEnabled = false;
                    editButton.IsEnabled = true;
                    saveButton.IsEnabled = false;
                    textTitle.IsEnabled = false;
                    textPublisher.IsEnabled = false;
                    break;
                case EditMode.CreateNew:
                case EditMode.Edit:
                    createButton.IsEnabled = false;
                    cancelButton.IsEnabled = true;
                    editButton.IsEnabled = false;
                    saveButton.IsEnabled = true;
                    textTitle.IsEnabled = true;
                    textPublisher.IsEnabled = true;
                    break;
                default:
                    break;
            }
            _currentMode = mode;
        }

        public enum EditMode
        {
            View,
            CreateNew,
            Edit
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            if (_currentMode == EditMode.Edit)
            {
                _booksService.CurrentBook.Title = textTitle.Text;
                _booksService.CurrentBook.Publisher = textPublisher.Text;
            }
            else if (_currentMode == EditMode.CreateNew)
            {
                _newBook.Title = textTitle.Text;
                _newBook.Publisher = textPublisher.Text;
                _booksService.AddBook(_newBook);
            }
            SetMode(EditMode.View);
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            SetMode(EditMode.View);
            _newBook = null;
        }

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            SetMode(EditMode.Edit);
        }
    }
}
