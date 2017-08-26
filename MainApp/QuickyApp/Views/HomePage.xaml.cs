using QuickyApp.Attributes;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    [ViewModelType(typeof(HomePageViewModel))]
    public partial class HomePage
    {
        private readonly HomePageViewModel _dataContext;

        public HomePage()
        {
            InitializeComponent();

            DataContext = new HomePageViewModel(this);
            _dataContext = (HomePageViewModel)DataContext;
        }
    }
}
