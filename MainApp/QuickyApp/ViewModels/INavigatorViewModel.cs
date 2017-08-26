using Windows.UI.Xaml.Controls;

namespace QuickyApp.ViewModels
{
    public interface INavigatorViewModel
    {
        Page AssociatedPage { get; set; }
    }
}