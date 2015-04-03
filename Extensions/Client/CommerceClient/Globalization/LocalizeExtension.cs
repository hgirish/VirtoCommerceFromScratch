using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Practices.ServiceLocation;

namespace CommerceClient.Globalization
{
    public static  class LocalizeExtension
    {
        public static string Localize(this string source)
        {
            return source.Localize((string)null);
        }

        private static string Localize(this string source, params object[] format)
        {
            return string.Format(source.Localize((string) null), format);
        }

        public static string Localize(this string source, string key, string category = "")
        {
            return source.Localize(key, category, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

        public static string Localize(this string source, string key, string category, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            var keySource = string.IsNullOrEmpty(key) ? source : key;
            key = Regex.Replace(keySource, @"\s+", "");
            key = key.Substring(0, Math.Min(key.Length, 128));

            return source.Map(key, category, culture ?? System.Threading.Thread.CurrentThread.CurrentUICulture).Value;
        }

        public static Element Map(this string source, string key, string category, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return Element.Empty;
            }

            var repository = ServiceLocator.Current.GetInstance<IElementRepository>();
            var element = repository.Get(key, category, culture.Name);

            if (element == null)
            {
                element = new Element
                {
                    Name = key,
                    Category = category,
                    Culture = culture.Name,
                    Value = source
                };
                repository.Add(element);
            }
            return element;
        }
    }
}