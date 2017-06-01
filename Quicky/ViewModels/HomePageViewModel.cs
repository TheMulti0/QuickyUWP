using System.ComponentModel;
using System.Runtime.CompilerServices;
using Quicky.Annotations;

namespace Quicky.ViewModels
{
    internal class HomePageViewModel : IPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}