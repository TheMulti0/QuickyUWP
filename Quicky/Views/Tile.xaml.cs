using Windows.UI.Core;
using Windows.UI.Xaml;
using Quicky.ViewModels;

namespace Quicky.Views
{
    public partial class Tile
    {
        public static readonly DependencyProperty IconProperty
            = DependencyProperty.Register("Icon", typeof(string), typeof(UIElement), null);

        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register("Title", typeof(string), typeof(UIElement), null);

        public static readonly DependencyProperty DescriptionProperty
            = DependencyProperty.Register("Description", typeof(string), typeof(UIElement), null);

        public Tile()
        {
            InitializeComponent();

            Window.Current.SizeChanged += Window_OnSizeChanged;
        }

        public string Icon
        {
            get => (string) GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Description
        {
            get => (string) GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        private void Window_OnSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            var mainPageVm = MainPage.ViewModel;

            mainPageVm.Height = e.Size.Height;
            var vm = (TileViewModel) DataContext;
            vm.FetchSizes(mainPageVm.Height);
        }
    }
}