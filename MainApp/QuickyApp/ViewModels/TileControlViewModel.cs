using System;
using Windows.Graphics.Display;

namespace QuickyApp.ViewModels
{
    internal class TileControlViewModel
    {
        public TileControlViewModel()
        {
            SetSizes();
        }

        private void SetSizes()
        {
            var displayInfo = DisplayInformation.GetForCurrentView();
            double height = displayInfo.ScreenHeightInRawPixels;

            var newHeight = height / 2.42;
            if (Math.Abs(TileHeight - height) < 0.0)
            {
                return;
            }

            TileHeight = newHeight;
            TileWidth = TileHeight;

            IconSize = TileHeight / 6;

            TitleFontSize = IconSize / 2.3;
            DescriptionFontSize = TitleFontSize / 1.25;
        }

        public double TileHeight { get; set; }

        public double TileWidth { get; set; }

        public double IconSize { get; set; }

        public double TitleFontSize { get; set; }

        public double DescriptionFontSize { get; set; }
    }
}