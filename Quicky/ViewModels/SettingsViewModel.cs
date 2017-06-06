using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Quicky.Annotations;
using Quicky.Views;

namespace Quicky.ViewModels
{
    public class SettingsViewModel : IViewModel
    {
        private double _colorPickerHeight;
        private double _colorPickerWidth;
        private Thickness _confirmationPanelMargin;

        public SettingsViewModel()
        {
            var height = MainPage.ViewModel.Height;
            FetchSizes(height);
        }

        public double ColorPickerHeight
        {
            get => _colorPickerHeight;
            set
            {
                _colorPickerHeight = value;
                OnPropertyChanged();
            }
        }

        public double ColorPickerWidth
        {
            get => _colorPickerWidth;
            set
            {
                _colorPickerWidth = value;
                OnPropertyChanged();
            }
        }

        public Thickness ConfirmationPanelMargin
        {
            get => _confirmationPanelMargin;
            set
            {
                _confirmationPanelMargin = value;
                OnPropertyChanged();
            }
        }

        public Color AccentColor { get; set; }

        public void FetchSizes(object size)
        {
            var newHeight = (double) size / 3.6;
            if (Math.Abs(ColorPickerHeight - newHeight) < 0.0)
            {
                return;
            }

            ColorPickerHeight = 1080 / 4.0;
            ColorPickerWidth = ColorPickerHeight;

            ConfirmationPanelMargin = new Thickness(ColorPickerHeight / 20);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}