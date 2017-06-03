namespace Quicky.Views
{
    public interface INavigationService
    {
        void Navigate(
            INavigationContainerPage container, INavigationPage navigation);
    }
}