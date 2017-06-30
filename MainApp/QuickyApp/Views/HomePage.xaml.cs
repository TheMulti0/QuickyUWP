using System.Diagnostics;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    public sealed partial class HomePage
    {
        private readonly HomePageViewModel _dataContext;

        public HomePage()
        {
            InitializeComponent();
            
            DataContext = new HomePageViewModel(this);
            _dataContext = (HomePageViewModel) DataContext;
        }
    }
}
