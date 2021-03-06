﻿namespace QuickyApp.TranslateApp.Engine
{
    public class TranslateEvent
    {
        public delegate void TranslateHandler(string messsage = null);

        public event TranslateHandler TranslateFailed;

        public virtual void OnTranslateFailed(string messsage = null)
        {
            TranslateFailed?.Invoke(messsage);
        }
    }
}