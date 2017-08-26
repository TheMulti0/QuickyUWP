using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using QuickyApp.Attributes;

namespace QuickyApp.ViewModels
{
    internal class TypesRegistry
    {
        //Key = View
        //Value = ViewModel
        private readonly Dictionary<Type, Type> _typesDictionary;

        public TypesRegistry()
        {
            _typesDictionary = new Dictionary<Type, Type>();

            Assembly assembly = typeof(TypesRegistry).GetTypeInfo().Assembly;

            var types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.FullName.Contains("Translate"))
                {
                    
                }
                try
                {
                    var vmTypeAttributes = (ViewModelTypeAttribute[]) type
                        .GetTypeInfo()
                        .GetCustomAttributes(typeof(ViewModelTypeAttribute));

                    foreach (ViewModelTypeAttribute attribute in vmTypeAttributes)
                    {
                        _typesDictionary.Add(type, attribute.ViewModelType);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public Type GetViewType(Type viewModelType)
        {
            var viewTypes = _typesDictionary
                .Where(e => e.Value == viewModelType);
            var viewType = viewTypes.FirstOrDefault();

            return viewType.Key;
        }

        public Type GetViewModelType(Type viewType)
        {
            var viewModelTypes = _typesDictionary
                .Where(e => e.Key == viewType);
            var viewModelType = viewModelTypes.FirstOrDefault();

            return viewModelType.Value;
        }
    }
}