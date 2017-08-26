using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using QuickyApp.TranslateApp.Engine.Enums;
using QuickyApp.TranslateApp.Engine.Events;
using QuickyApp.TranslateApp.Engine.Wcf;

namespace QuickyApp.TranslateApp.Engine.Translators
{
    internal class SeleniumGoogleTranslator : ITranslator<TranslateLanguages, RemoteWebDriver>
    {
        private static readonly TranslateEvent TranslateEvent;

        static SeleniumGoogleTranslator()
        {
            TranslateEvent = new TranslateEvent();
        }

        public TranslateWord Translate(
            TranslateWord word,
            TranslateLanguages translatedLanguage,
            RemoteWebDriver driver)
        {
            TypeWordInTextBox(word, driver);
            SelectTranslatedLanguage(translatedLanguage, driver);

            var resultBox = driver.FindElementById("result_box");
            var result = resultBox.Text;

            if (result == "")
            {
                var translateButton = driver.FindElementById("gt-submit");
                translateButton.Click();
            }

            driver.Quit();

            var translateWord = new TranslateWord
            {
                Language = Detect(word, driver).Language,
                Word = result
            };
            return translateWord;
        }

        public TranslateWord Detect(TranslateWord word, RemoteWebDriver driver)
        {
            var detectButton = driver.FindElementByXPath("//*[@id=\"gt-sl-sugg\"]/div[5]");
            detectButton.Click();

            TypeWordInTextBox(word, driver);

            var lang = detectButton.Text?.Replace(" - detected", "");
            var @enum = EnumParser.GetEnum(lang, typeof(TranslateLanguages));
            driver.Quit();

            var translateWord = new TranslateWord
            {
                Language = (TranslateLanguages) @enum,
                Word = word.Word
            };
            return translateWord;
        }

        private static void TypeWordInTextBox(TranslateWord word, IFindsById driver)
        {
            var textBox = driver.FindElementById("source");
            textBox.SendKeys(word.Word);
        }

        private static void SelectTranslatedLanguage(
            TranslateLanguages translatedLanguage,
            RemoteWebDriver driver)
        {
            var lang = EnumParser.GetString(translatedLanguage);
            var langItem = By.XPath(
                $"//*[contains(text(), '{lang}')]");

            try
            {
                driver.FindElement(langItem);
            }
            catch (NoSuchElementException)
            {
                var moreButton = driver.FindElementById("gt-tl-gms");
                moreButton.Click();

                try
                {
                    var traits = new List<By>
                    {
                        langItem,
                        By.ClassName("goog-menuitem-content")
                    };
                    var langOption = driver.FindElementByTraits(traits);
                    langOption.Click();
                }
                catch (NoSuchElementException)
                {
                    driver.Quit();
                    TranslateEvent.OnTranslateFailed();
                }
            }
        }
    }
}