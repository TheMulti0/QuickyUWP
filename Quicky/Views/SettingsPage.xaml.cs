using System;
using Windows.UI.Xaml;
using Quicky.ViewModels;

namespace Quicky.Views
{
    public sealed partial class SettingsPage : INavigationPage
    {
        public Type PageType { get; set; }

        public static SettingsViewModel ViewModel { get; set; }

        public SettingsPage()
        {
            InitializeComponent();

            ViewModel = new SettingsViewModel();
            DataContext = ViewModel;

            PageType = typeof(SettingsPage);
        }

        private void FlyoutOkButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.AccentColor = ColorPicker.Color;

            ColorPickerFlyout.Hide();
        }

        private void FlyoutCancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ColorPickerFlyout.Hide();
        }
    }
}