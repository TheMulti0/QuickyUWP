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
    }
}