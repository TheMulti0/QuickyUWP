using System.ServiceModel;
using QuickyApp.TranslateApp.Engine.Enums;

namespace QuickyApp.TranslateApp.Engine.Wcf
{
    [ServiceContract]
    public interface ITranslateService
    {
        [OperationContract]
        void Initialize(DriverTypes driverType, string driverPath);

        [OperationContract]
        TranslateWord Translate(TranslateWord word, TranslateLanguages translatedLanguage);

        [OperationContract]
        TranslateWord Detect(TranslateWord word);
    }
}