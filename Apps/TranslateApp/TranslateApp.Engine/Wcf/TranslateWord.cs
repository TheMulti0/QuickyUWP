using QuickyApp.TranslateApp.Engine.Enums;

namespace QuickyApp.TranslateApp.Engine.Wcf
{
    public class TranslateWord : ITranslateWord
    {
        public string Word { get; set; }

        public TranslateLanguages Language { get; set; }
    }
}