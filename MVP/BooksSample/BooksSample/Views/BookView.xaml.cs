using BooksSample.Models;
using BooksSample.Presenters;
using BooksSample.Services;
using System.Windows;
using System.Windows.Controls;

namespace BooksSample.Views
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView : UserControl, IBookView
    {
        private BookViewPresenter _bookViewPresenter;

        public BookView()
        {
            InitializeComponent();
            _bookViewPresenter = new BookViewPresenter(this);

        }

        public Button CreateButton => createButton;
        public Button CancelButton => cancelButton;
        public Button EditButton => editButton;
        public Button SaveButton => saveButton;
        public TextBox TextId => textId;
        public TextBox TextTitle => textTitle;
        public TextBox TextPublisher => textPublisher;

        private void OnCreate(object sender, RoutedEventArgs e)
        {
            _bookViewPresenter.CreateBook();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            _bookViewPresenter.SaveBook();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            _bookViewPresenter.CancelEdit();
        }

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            _bookViewPresenter.SetEdit();
        }
    }
}
