using System;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;

namespace QuickyApp.ViewModels
{
    internal class SettingsPageViewModel : ViewModelBase, INavigatorViewModel
    {
        public SettingsPageViewModel()
        {
            Initialize();
        }

        public SettingsPageViewModel(Page page)
        {
            AssociatedPage = page;

            Initialize();
        }

        private void Initialize()
        {
            SetSizes();
        }

        private Color _accentColor;

        private bool _isOpen;

        private FrameworkElement _parent;

        public Page AssociatedPage { get; set; }

        public double ColorPickerHeight { get; set; }

        public double ColorPickerWidth { get; set; }

        public double HeaderFontSize { get; set; }

        public double LabelFontSize { get; set; }

        public double ChooseColorButtonHeight { get; set; }

        public double ChooseColorButtonWidth { get; set; }

        public double FlyoutColorPickerButtonHeight { get; set; }

        public double FlyoutColorPickerButtonWidth { get; set; }

        public Thickness FlyoutColorPickerButtonHorizontalMargin { get; set; }

        public Thickness FlyoutColorPickerMargin { get; set; }

        public Thickness VerticalSpaceMargin { get; set; }

        public Thickness RightSpaceMargin { get; set; }

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

            var colorPickerHeight = height / 4;
            if (Math.Abs(ColorPickerHeight - colorPickerHeight) < 0.0)
            {
                return;
            }

            ColorPickerHeight = colorPickerHeight;
            ColorPickerWidth = ColorPickerHeight;

            FlyoutColorPickerButtonWidth = ColorPickerHeight / 2.7;
            FlyoutColorPickerButtonHeight = FlyoutColorPickerButtonWidth / 5;

            SetMarginProperties();

            HeaderFontSize = FlyoutColorPickerButtonWidth / 2.5;
            LabelFontSize = HeaderFontSize / 1.3333333333333333;

            ChooseColorButtonHeight = LabelFontSize / 1.5;
            ChooseColorButtonWidth = ChooseColorButtonHeight;
        }

        private void SetMarginProperties()
        {
            FlyoutColorPickerMargin = new Thickness(0, ColorPickerHeight / 20, 0, 0);

            var horizontalMargin = (ColorPickerHeight - FlyoutColorPickerButtonWidth * 2) / 4;
            FlyoutColorPickerButtonHorizontalMargin = new Thickness(horizontalMargin, 0, horizontalMargin, 0);

            var rightSpace = LabelFontSize / 5;
            RightSpaceMargin = new Thickness(0, 0, rightSpace, 0);
        }
    }
}