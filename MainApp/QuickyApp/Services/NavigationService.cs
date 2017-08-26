using System;
using System.Linq;
using System.Reflection;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using QuickyApp.ViewModels;
using QuickyApp.Views;

namespace QuickyApp.Services
{
    internal class NavigationService : INavigationService
    {
        private Page _containerPage;

        public event NavigatedEventHandler NavigatedToPage;

        public NavigationService()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
            NavigatedToPage += OnNavigatedToPage;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!_containerPage.Frame.CanGoBack)
            {
                return;
            }

            _containerPage.Frame.GoBack();
            NavigatedToPage?.Invoke(sender, null);
            e.Handled = true;
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {
            ChangeBackButtonVisibility(_containerPage.Frame.CanGoBack 
                && _containerPage.Frame.CurrentSourcePageType != typeof(HomePage)
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed);

            void ChangeBackButtonVisibility(AppViewBackButtonVisibility visibility)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                    = visibility;
            }
        }

        public void Navigate(Type viewModelType, INavigatorViewModel containerViewModel)
        {
            Type pageType = new TypesRegistry().GetViewType(viewModelType);
            _containerPage = containerViewModel.AssociatedPage;

            _containerPage.Frame.Navigate(pageType);

            NavigatedToPage?.Invoke(null, null);
        }
    }
}