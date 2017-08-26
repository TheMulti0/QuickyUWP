using System;

namespace QuickyApp.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ViewModelTypeAttribute : Attribute
    {
        public Type ViewModelType { get; set; }

        public ViewModelTypeAttribute(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}