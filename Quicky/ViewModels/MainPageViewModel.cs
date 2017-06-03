﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Quicky.Properties;

namespace Quicky.ViewModels
{
    public class MainPageViewModel : IViewModel
    {
        public MainPageViewModel()
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

        public UIElement Content { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}