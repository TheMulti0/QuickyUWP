using System;
using Windows.UI.Xaml.Navigation;
using QuickyApp.ViewModels;

namespace QuickyApp.Services
{
    internal interface INavigationService
    {
        event NavigatedEventHandler NavigatedToPage;

        void Navigate(INavigatorViewModel navVm, INavigatorViewModel containerVm);

        Type GetType(object page);
    }
}