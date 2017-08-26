using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;

namespace QuickyApp.TranslateApp.Engine
{
    internal class SeleniumGoogleTranslator : ITranslator<TranslateLanguages, RemoteWebDriver>
    {
        private static readonly TranslateEvent TranslateEvent;

        static SeleniumGoogleTranslator()
        {
            TranslateEvent = new TranslateEvent();
        }

        public string Translate(
            string word,
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

            return result;;
        }

        public TranslateLanguages Detect(string word, RemoteWebDriver driver)
        {
            var detectButton = driver.FindElementByXPath("//*[@id=\"gt-sl-sugg\"]/div[5]");
            detectButton.Click();

            TypeWordInTextBox(word, driver);

            var lang = detectButton.Text?.Replace(" - detected", "");
            var @enum = GetEnum(lang, typeof(TranslateLanguages));
            driver.Quit();
            
            return (TranslateLanguages) @enum;
        }

        private static void TypeWordInTextBox(string word, IFindsById driver)
        {
            var textBox = driver.FindElementById("source");
            textBox.SendKeys(word);
        }

        private static void SelectTranslatedLanguage(
            TranslateLanguages translatedLanguage,
            RemoteWebDriver driver)
        {
            var lang = GetString(translatedLanguage);
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

        private static string GetString(Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());
            var attributes =
                (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0
                ? attributes[0].Description
                : @enum.ToString();
        }

        private static Enum GetEnum(string value, Type @enum)
        {
            var names = Enum.GetNames(@enum);
            foreach (var name in names)
            {
                var enumValue = (Enum) Enum.Parse(@enum, name);
                if (GetString(enumValue) == value)
                {
                    return enumValue;
                }
            }

            throw new ArgumentException("The string does not exist in the enum.");
        }
    }
}