using QuickyApp.TranslateApp.UI.TranslateService;

namespace QuickyApp.TranslateApp.UI.ViewModels
{
    internal class TranslatePageViewModel : PropertyChangedContainer
    {
        private TranslateWord _sourceText;

        public TranslateWord SourceText
        {
            get => _sourceText;
            set
            {
                if (_sourceText == value)
                {
                    return;
                }
                _sourceText = value;
                OnPropertyChanged();
            }
        }
    }
}