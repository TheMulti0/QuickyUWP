using System;

namespace Quicky.Views
{
    public interface INavigationPage
    {
        Type PageType { get; set; }
    }
}