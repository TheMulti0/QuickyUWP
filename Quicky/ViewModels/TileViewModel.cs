using System;
using Windows.UI.Xaml;

namespace Quicky.ViewModels
{
    internal class TileViewModel
    {
        public TileViewModel()
        {
            Func<double, double> mathFunc = Math.Ceiling;

            var sizeInfo = Window.Current.Bounds;
            Height = (int) mathFunc(sizeInfo.Height / 3.6);
            Width = Height;

            IconHeight = (int) mathFunc(Height / 6.0);
            IconWidth = IconHeight;

            TitleFontSize = (int) mathFunc(IconHeight / 2.625);
            DescriptionFontSize = (int) mathFunc(TitleFontSize / 1.5);
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public int IconHeight { get; set; }

        public int IconWidth { get; set; }

        public int TitleFontSize { get; set; }

        public int DescriptionFontSize { get; set; }
    }
}