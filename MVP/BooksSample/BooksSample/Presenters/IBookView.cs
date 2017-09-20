using System.Windows.Controls;

namespace BooksSample.Presenters
{
    public interface IBookView
    {
        Button CreateButton { get; }
        Button CancelButton { get; }
        Button EditButton { get; }
        Button SaveButton { get; }
        TextBox TextId { get; }
        TextBox TextTitle { get; }
        TextBox TextPublisher { get; }
        
    }
}