using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Views;
using QuickyApp.ViewModels;
using NavigationService = QuickyApp.Services.NavigationService;

namespace QuickyApp.Views
{
    public partial class TileControl
    {
        public static readonly DependencyProperty NavigationContainerViewModelProperty
            = DependencyProperty.Register(
                "NavigationContainerViewModel",
                typeof(INavigatorViewModel),
                typeof(UIElement),
                null);

        public static readonly DependencyProperty NavigatorViewModelProperty
            = DependencyProperty.Register(
                "NavigatorViewModel",
                typeof(INavigatorViewModel),
                typeof(UIElement),
                null);

        public static readonly DependencyProperty IconProperty
            = DependencyProperty.Register("Icon", typeof(string), typeof(UIElement), null);
        
        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register("Title", typeof(string), typeof(UIElement), null);

        public static readonly DependencyProperty DescriptionProperty
            = DependencyProperty.Register("Description", typeof(string), typeof(UIElement), null);

        public TileControl()
        {
            InitializeComponent();
        }

        public INavigatorViewModel NavigationContainerViewModel
        {
            get => (INavigatorViewModel) GetValue(NavigationContainerViewModelProperty);
            set => SetValue(NavigationContainerViewModelProperty, value);
        }

        public INavigatorViewModel NavigatorViewModel
        {
            get => (INavigatorViewModel) GetValue(NavigatorViewModelProperty);
            set => SetValue(NavigatorViewModelProperty, value);
        }

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        private void Tile_ViewModelNavigation(object sender, RoutedEventArgs e)
        {
            var navService = new NavigationService();
            navService.Navigate(NavigatorViewModel, NavigationContainerViewModel);
        }
    }
}