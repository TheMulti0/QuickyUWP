using Windows.UI.Xaml;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    public sealed partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            DataContext = new SettingsPageViewModel(this);
        }

        private void CloseAccentColorFlyout(object sender, RoutedEventArgs e)
        {
            AccentColorButton.Flyout?.Hide();
        }
    }
}