using Windows.UI.Xaml;
using QuickyApp.Attributes;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    [ViewModelType(typeof(SettingsPageViewModel))]
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