using Windows.UI.Xaml;

namespace Quicky.Views
{
    public sealed partial class Tile
    {
        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register("Title", typeof(string), typeof(UIElement), null);

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty
            = DependencyProperty.Register("Description", typeof(string), typeof(UIElement), null);

        public string Description
        {
            get => (string) GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public Tile()
        {
            InitializeComponent();
        }
    }
}
