using System.ComponentModel;
using System.Runtime.CompilerServices;
using QuickyApp.TranslateApp.UI.Properties;

namespace QuickyApp.TranslateApp.UI.ViewModels
{
    internal class PropertyChangedContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}