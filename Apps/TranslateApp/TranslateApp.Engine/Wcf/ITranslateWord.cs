using System.ServiceModel;
using QuickyApp.TranslateApp.Engine.Enums;

namespace QuickyApp.TranslateApp.Engine.Wcf
{
    [ServiceContract]
    public interface ITranslateWord
    {
        string Word
        {
            [OperationContract]
            get;

            [OperationContract]
            set;
        }

        TranslateLanguages Language
        {
            [OperationContract]
            get;

            [OperationContract]
            set;
        }
    }
}
