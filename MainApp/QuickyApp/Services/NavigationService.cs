using System;
using System.Linq;
using System.Reflection;
using Windows.UI.Core;
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

        public void Navigate(INavigatorViewModel navVm, INavigatorViewModel containerVm)
        {
            _containerPage = containerVm.ContainerPage;

            var chosenType = GetType(navVm);

            containerVm.ContainerPage.Frame.Navigate(chosenType);

            NavigatedToPage?.Invoke(null, null);
        }

        public Type GetType(object page)
        {
            Type result;
            try
            {
                result = GetPageType(page);
            }
            catch (InvalidCastException)
            {
                result = GetViewModelType(page);
            }
            catch (NotSupportedException)
            {
                result = GetViewModelType(page);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private static Type GetViewModelType(object page)
        {
            if (page.GetType() != typeof(Page))
            {
                throw new NotSupportedException();
            }
            if (page is HomePage)
            {
                return GetPageType(typeof(HomePageViewModel));
            }
            if (page is SettingsPage)
            {
                return GetPageType(typeof(SettingsPageViewModel));
            }

            throw new NotImplementedException();
        }

        private static Type GetPageType(object viewModel)
        {
            Type viewModelType = viewModel.GetType();
            if (!viewModelType.GetInterfaces().Contains(typeof(INavigatorViewModel)))
            {
                throw new NotSupportedException();
            }
            if (viewModelType == typeof(HomePageViewModel))
            {
                return typeof(HomePage);
            }
            if (viewModelType == typeof(SettingsPageViewModel))
            {
                return typeof(SettingsPage);
            }

            throw new NotImplementedException();
        }
    }
}