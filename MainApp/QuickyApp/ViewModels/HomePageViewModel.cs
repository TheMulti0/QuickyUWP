using System;
using Windows.UI.Xaml.Controls;

namespace QuickyApp.ViewModels
{
    internal class HomePageViewModel : INavigatorViewModel
    {
        public Type PageViewModelType { get; set; }

        public Page ContainerPage { get; set; }

        public HomePageViewModel(Page page)
        {
            PageViewModelType = typeof(HomePageViewModel);

            ContainerPage = page;
        }
    }
}