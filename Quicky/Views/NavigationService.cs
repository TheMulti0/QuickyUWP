using Windows.UI.Xaml.Controls;

namespace Quicky.Views
{
    public class NavigationService : INavigationService
    {
        public void Navigate(
            INavigationContainerPage container, INavigationPage navigation)
        {
            var containerFrame = ((Page) container).Frame;
            var navigationType = navigation.PageType;

            containerFrame.Navigate(navigationType);
        }
    }
}