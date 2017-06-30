using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QuickyApp.ViewModels
{
    internal class TileControlViewModel : PropertyChangedContainer
    {
        private double _appWidth;

        public double AppWidth
        {
            get => _appWidth;
            set
            {
                _appWidth = value;
                OnPropertyChanged();
            }
        }

        public TileControlViewModel()
        {
            Window.Current.SizeChanged += 
                (sender, args) => 
                AppWidth = ((Frame)Window.Current.Content).ActualWidth;
        }

    }
}