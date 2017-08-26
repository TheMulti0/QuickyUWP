using Windows.UI.Xaml.Controls;
using QuickyApp.Attributes;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    [ViewModelType(typeof(TranslatePageViewModel))]
    public sealed partial class TranslatePage : Page
    {
        public TranslatePage()
        {
            InitializeComponent();

            DataContext = new TranslatePageViewModel(this);
        }
    }
}