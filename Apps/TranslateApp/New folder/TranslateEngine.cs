using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace QuickyApp.TranslateApp.Engine
{
    public class TranslateEngine
    {
        private readonly RemoteWebDriver _driver;
        private readonly ITranslator<TranslateLanguages, RemoteWebDriver> _translator;

        public void TranslateEngine(string driverPath)
        {
            _driver = DriverFactory(driverPath);

            _translator = new SeleniumGoogleTranslator();
        }

        public string Translate(string word, TranslateLanguages translatedLanguage)
            => _translator.Translate(word, translatedLanguage, _driver);

        public TranslateLanguages Detect(string word)
            => _translator.Detect(word, _driver);

        private static RemoteWebDriver DriverFactory(string driverPath)
            => SeleniumDriverFactory.Factory(typeof(PhantomJSDriver), driverPath);
    }
}
