using System.ComponentModel;
using System.Runtime.CompilerServices;
using QuickyApp.Annotations;

namespace QuickyApp.ViewModels
{
    internal class PropertyChangedContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}