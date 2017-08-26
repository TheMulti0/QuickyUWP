using System;
using OpenQA.Selenium.Remote;
using QuickyApp.TranslateApp.Engine.Enums;
using QuickyApp.TranslateApp.Engine.Factories;
using QuickyApp.TranslateApp.Engine.Translators;

namespace QuickyApp.TranslateApp.Engine.Wcf
{
    public class TranslateService : ITranslateService
    {
        private RemoteWebDriver _driver;
        private ITranslator<TranslateLanguages, RemoteWebDriver> _translator;

        public void Initialize(DriverTypes driverType, string driverPath)
        {
            _driver = DriverFactory(driverType, driverPath);

            _translator = new SeleniumGoogleTranslator();
        }

        public TranslateWord Translate(TranslateWord word, TranslateLanguages translatedLanguage)
            => _translator.Translate(word, translatedLanguage, _driver);

        public TranslateWord Detect(TranslateWord word)
            => _translator.Detect(word, _driver);

        private static RemoteWebDriver DriverFactory(DriverTypes driverType, string driverPath)
            => SeleniumDriverFactory.Factory(
                Type.GetType(driverType.ToString()),
                driverPath);
    }
}