using System.ComponentModel;

namespace Quicky.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void FetchSizes(object size);
    }
}