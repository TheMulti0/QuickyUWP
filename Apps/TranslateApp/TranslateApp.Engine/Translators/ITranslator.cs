using QuickyApp.TranslateApp.Engine.Wcf;

namespace QuickyApp.TranslateApp.Engine.Translators
{
    internal interface ITranslator<T, in TE>
    {
        TranslateWord Translate(
            TranslateWord word,
            T translatedLanguage,
            TE driver);

        TranslateWord Detect(TranslateWord word, TE driver);
    }
}