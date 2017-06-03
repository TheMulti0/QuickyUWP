using System;

namespace Quicky.Views
{
    public sealed partial class HomePage : INavigationPage
    {
        public Type PageType { get; set; }

        public HomePage()
        {
            InitializeComponent();

            PageType = typeof(HomePage);
        }
    }
}