using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Unity;
using Quicky.ViewModels;

namespace Quicky.Views
{
    public sealed partial class MainPage : INavigationContainerPage
    {
        public MainPage()
        {
            InitializeComponent();

            ViewModel = new MainPageViewModel();
            DataContext = ViewModel;

            ViewModel.Content = new HomePage();

            
            Window.Current.VisibilityChanged += (sender, args) =>
            {
                IUnityContainer container = new UnityContainer();

                container.RegisterInstance<INavigationContainerPage>(this);
                container.RegisterInstance<INavigationPage>(ViewModel.Content);

                container.Resolve<NavigationService>();
            };
        }

        public static MainPageViewModel ViewModel { get; set; }

        public static INavigationService NavigationService { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack && rootFrame != Frame)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
}