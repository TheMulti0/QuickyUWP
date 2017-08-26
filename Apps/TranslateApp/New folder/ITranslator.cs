namespace QuickyApp.TranslateApp.Engine
{
    internal interface ITranslator<T, in TE>
    {
        string Translate(
            string word,
            T translatedLanguage,
            TE driver);

        T Detect(string word, TE driver);
    }
}