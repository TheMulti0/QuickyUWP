using Windows.UI.Xaml.Controls;
using QuickyApp.TranslateApp.UI.Services;
using QuickyApp.TranslateApp.UI.TranslateService;
using QuickyApp.TranslateApp.UI.ViewModels;

namespace QuickyApp.TranslateApp.UI.Views
{
    public sealed partial class TranslateControl : UserControl
    {
        private readonly TranslatePageViewModel _vm;

        private readonly Translator _translator;

        public TranslateControl()
        {
            InitializeComponent();
            
            _vm = (TranslatePageViewModel) DataContext;

            _translator = new Translator();
            _translator.InitializeAsync(DriverTypes.ChromeDriver, @"C:\Users\Davids_old\Documents\Programming\C#\UWP\Quicky");
        }

        private async void SourceText_OnChanged(object sender, TextChangedEventArgs e)
        {
            var translatedWord = await _translator.TranslateAsync(_vm.SourceText, TranslateLanguages.French);
            _vm.SourceText = translatedWord;
        }
    }
}