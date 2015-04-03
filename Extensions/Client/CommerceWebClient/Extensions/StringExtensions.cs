using System.Web.UI.WebControls;

namespace CommerceWebClient.Extensions
{
    public static  class StringExtensions
    {
        public static string Title(this string title)
        {
            return Title(title, "{0} | {1}");
        }

        public static string Title(this string title, string formatString)
        {
            var storeName = StoreHelper.CustomerSession.StoreName;
            return string.IsNullOrEmpty(storeName)
                ? title
                : string.Format(formatString, title, storeName);
        }
    }
}