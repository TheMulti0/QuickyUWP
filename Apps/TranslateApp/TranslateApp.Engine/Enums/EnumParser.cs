using System;
using System.ComponentModel;

namespace QuickyApp.TranslateApp.Engine.Enums
{
    internal static class EnumParser
    {
        public static string GetString(Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());
            var attributes =
                (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0
                ? attributes[0].Description
                : @enum.ToString();
        }

        public static Enum GetEnum(string value, Type @enum)
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