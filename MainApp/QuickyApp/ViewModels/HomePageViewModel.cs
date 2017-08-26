using Windows.UI.Xaml.Controls;

namespace QuickyApp.ViewModels
{
    internal class HomePageViewModel : INavigatorViewModel
    {
        public Page AssociatedPage { get; set; }

        public HomePageViewModel(Page page)
        {
            AssociatedPage = page;
        }
    }
}