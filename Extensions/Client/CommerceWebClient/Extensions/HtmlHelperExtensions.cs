using System.Reflection;
using System.Web.Mvc;
using CommerceFoundation.Frameworks.Extensions;

namespace CommerceWebClient.Extensions
{
    public static  class HtmlHelperExtensions
    {
        private static MvcHtmlString _version;

        public static MvcHtmlString Version(this HtmlHelper html)
        {
            if (_version == null)
            {
                var assembly = Assembly.GetExecutingAssembly();
                _version = new MvcHtmlString(string.Format("{0} (Build {1}",
                  assembly.GetInformationalVersion(), assembly.GetFileVersion()  ));
            }
            return _version;
        }
    }
}