using System;

namespace Quicky.Views
{
    public sealed partial class SettingsPage : INavigationPage
    {
        public Type PageType { get; set; }

        public SettingsPage()
        {
            InitializeComponent();

            PageType = typeof(SettingsPage);
        }
    }
}