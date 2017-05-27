using System;
using Windows.UI.Xaml.Controls;
using Quicky.Views;

namespace Quicky.ViewModels
{
    public class MainPageViewModel
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public Page CurrentPage { get; set; }

        public MainPageViewModel()
        {
            CurrentPage = GetPage(PageState.HomePage);
            
            var screenInfo = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
            Height = Math.Ceiling(screenInfo.ScreenHeightInRawPixels / 1.25);
            Width = Math.Ceiling(screenInfo.ScreenWidthInRawPixels / 1.25);
        }

        public Page GetPage(PageState page)
        {
            switch (page)
            {
                default:
                    throw new NotImplementedException();

                case PageState.HomePage:
                    return new HomePage();
            }
        }

        public enum PageState
        {
            HomePage
        }
    }
}