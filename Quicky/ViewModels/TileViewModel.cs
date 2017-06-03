using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Quicky.Annotations;
using Quicky.Views;

namespace Quicky.ViewModels
{
    internal class TileViewModel : IViewModel
    {
        private double _descriptionFontSize;
        private double _height;
        private double _iconSize;
        private double _titleFontSize;
        private double _width;

        public TileViewModel()
        {
            var height = MainPage.ViewModel.Height;
            FetchSizes(height);
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        public double IconSize
        {
            get => _iconSize;
            set
            {
                _iconSize = value;
                OnPropertyChanged();
            }
        }

        public double TitleFontSize
        {
            get => _titleFontSize;
            set
            {
                _titleFontSize = value;
                OnPropertyChanged();
            }
        }

        public double DescriptionFontSize
        {
            get => _descriptionFontSize;
            set
            {
                _descriptionFontSize = value;
                OnPropertyChanged();
            }
        }

        public void FetchSizes(object size)
        {
            var newHeight = (double) size / 3.6;
            if (Math.Abs(Height - newHeight) < 0.0)
            {
                return;
            }
            Height = newHeight;
            Width = Height;

            IconSize = Height / 6.0;

            TitleFontSize = IconSize / 2.3;
            DescriptionFontSize = TitleFontSize / 1.25;

            const double tolerance = 1.8;
            Height *= tolerance;
            Width *= tolerance;
            IconSize *= tolerance;
            TitleFontSize *= tolerance;
            DescriptionFontSize *= tolerance;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}