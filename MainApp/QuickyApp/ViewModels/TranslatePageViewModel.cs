using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using QuickyApp.Views;

namespace QuickyApp.ViewModels
{
    internal class TranslatePageViewModel : INavigatorViewModel
    {
        public Page AssociatedPage { get; set; }

        public TranslatePageViewModel()
        {

        }

        public TranslatePageViewModel(Page page)
        {
            AssociatedPage = page;
        }
    }
}
