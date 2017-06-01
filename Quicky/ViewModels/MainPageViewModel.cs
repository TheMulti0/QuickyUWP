using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Quicky.Annotations;

namespace Quicky.ViewModels
{
    public class MainPageViewModel : IPageViewModel
    {
        public double Size { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public IPageViewModel CurrentPage { get; set; }

        public MainPageViewModel()
        {
            CurrentPage = GetPage(PageState.HomePage);
            
            var screenInfo = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
            Height = Math.Ceiling(screenInfo.ScreenHeightInRawPixels / 1.25);
            Width = Math.Ceiling(screenInfo.ScreenWidthInRawPixels / 1.25);
        }

        public IPageViewModel GetPage(PageState page)
        {
            switch (page)
            {
                default:
                    throw new NotImplementedException();

                case PageState.HomePage:
                    return new HomePageViewModel();
            }
        }

        public enum PageState
        {
            HomePage
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}