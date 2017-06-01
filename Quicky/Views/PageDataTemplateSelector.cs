using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Quicky.ViewModels;

namespace Quicky.Views
{
    internal class PageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HomePageTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var mainPageVm =
                (MainPageViewModel)
                ((Page)
                ((Frame)Window.Current.Content)
                .Content)
                ?.DataContext;
            IPageViewModel currentPage = mainPageVm?.CurrentPage;

            if (currentPage is HomePageViewModel)
            {
                return HomePageTemplate;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
