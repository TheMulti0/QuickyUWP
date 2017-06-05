using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Unity;
using Quicky.ViewModels;

namespace Quicky.Views
{
    public sealed partial class MainPage : INavigationContainerPage
    {
        public static MainPage CurrentInstance { get; set; }

        public static MainPageViewModel ViewModel { get; set; }

        public event NavigatedEventHandler NavigatedToPage;

        public MainPage()
        {
            InitializeComponent();

            CurrentInstance = this;

            ViewModel = new MainPageViewModel();
            DataContext = ViewModel;

            ViewModel.Content = new HomePage();

            NavigatedToPage += OnNavigatedToPage;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
            Window.Current.VisibilityChanged += NavigateToHome;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                OnNavigatedToPage(null, null);
                e.Handled = true;
            }
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {
            ChangeBackButtonVisibility(Frame.CanGoBack && Frame.CurrentSourcePageType != typeof(HomePage)
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed);

            void ChangeBackButtonVisibility(AppViewBackButtonVisibility visibility)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility
                    = visibility;
            }
        }

        public void NavigateToPage(INavigationPage navPage)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterInstance<INavigationContainerPage>(this);
            container.RegisterInstance(navPage);

            container.Resolve<NavigationService>();

            NavigatedToPage?.Invoke(null, null);
        }

        private void NavigateToHome(object sender, VisibilityChangedEventArgs args)
        {
            NavigateToPage(ViewModel.Content);

            Window.Current.VisibilityChanged -= NavigateToHome;
        }
    }
}