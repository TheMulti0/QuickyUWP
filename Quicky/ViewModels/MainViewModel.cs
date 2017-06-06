using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Graphics.Display;
using Quicky.Annotations;
using Quicky.Views;

namespace Quicky.ViewModels
{
    public class MainViewModel : IViewModel
    {
        public MainViewModel()
        {
            var screenInfo = DisplayInformation.GetForCurrentView();
            FetchSizes(screenInfo);
        }

        public void FetchSizes(object size)
        {
            var screenInfo = (DisplayInformation) size;
            Height = screenInfo.ScreenHeightInRawPixels / 1.25;
            Width = screenInfo.ScreenWidthInRawPixels / 1.25;
        }

        public double Size { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public INavigationPage Content { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}