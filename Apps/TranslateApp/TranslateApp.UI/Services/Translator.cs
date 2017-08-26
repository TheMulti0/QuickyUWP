using System.Threading.Tasks;
using QuickyApp.TranslateApp.UI.TranslateService;

namespace QuickyApp.TranslateApp.UI.Services
{
    internal class Translator
    {
        private readonly ITranslateService _service 
            = new TranslateServiceClient();

        public async Task InitializeAsync(DriverTypes driverType, string driverPath) 
            => await _service.InitializeAsync(driverType, driverPath);

        public async Task<TranslateWord> TranslateAsync(
            TranslateWord word,
            TranslateLanguages translatedLanguage) 
            => await _service.TranslateAsync(word, translatedLanguage);

        public async Task<TranslateWord> DetectAsync(TranslateWord word) 
            => await _service.DetectAsync(word);
    }
}