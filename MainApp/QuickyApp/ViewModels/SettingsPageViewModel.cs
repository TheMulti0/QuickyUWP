using System;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace QuickyApp.ViewModels
{
    internal class SettingsPageViewModel : ViewModelBase, INavigatorViewModel
    {
        private Color _accentColor;
        private bool _isOpen;
        private FrameworkElement _parent;

        public Type PageViewModelType { get; set; }

        public Page ContainerPage { get; set; }

        public SettingsPageViewModel()
        {
            Initialize();
        }

        public SettingsPageViewModel(Page page)
        {
            PageViewModelType = typeof(SettingsPageViewModel);

            ContainerPage = page;

            Initialize();
        }

        private void Initialize()
        {
            CloseCommand = new RelayCommand(() => IsOpen = false);

            SetSizes();
        }

        public double ColorPickerHeight { get; set; }

        public double ColorPickerWidth { get; set; }

        public Thickness ConfirmationPanelMargin { get; set; }

        public double HeaderFontSize { get; set; }

        public double LabelFontSize { get; set; }

        public RelayCommand CloseCommand { get; set; }

        public Color AccentColor
        {
            get => _accentColor;
            set
            {
                _accentColor = value;
                RaisePropertyChanged();
            }
        }

        public bool IsOpen
        {
            get => _isOpen;
            set => Set(ref _isOpen, value);
        }

        public FrameworkElement Parent
        {
            get => _parent;
            set => Set(ref _parent, value);
        }

        private void SetSizes()
        {
            var displayInfo = DisplayInformation.GetForCurrentView();
            double height = displayInfo.ScreenHeightInRawPixels;

            var colorPickerHeight = height / 2.42;
            if (Math.Abs(ColorPickerHeight - colorPickerHeight) < 0.0)
            {
                return;
            }

            ColorPickerHeight = colorPickerHeight;
            ColorPickerWidth = ColorPickerHeight;

            HeaderFontSize = ColorPickerHeight / 6;
            LabelFontSize = HeaderFontSize / 1.3333333333333333;

            ConfirmationPanelMargin = new Thickness(ColorPickerHeight / 20);
        }
    }
}