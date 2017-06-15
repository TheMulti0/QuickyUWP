using System;
using Windows.UI.Xaml.Controls;

namespace QuickyApp.ViewModels
{
    public interface INavigatorViewModel
    {
        Type PageViewModelType { get; set; }

        Page ContainerPage { get; set; }
    }
}