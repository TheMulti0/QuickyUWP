using System;
using Windows.UI.Xaml;

namespace Quicky.Views
{
    public sealed partial class HomePage : INavigationPage
    {
        public Type PageType { get; set; }

        public HomePage()
        {
            InitializeComponent();

            PageType = typeof(HomePage);
        }

        private void SettingsTile_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}