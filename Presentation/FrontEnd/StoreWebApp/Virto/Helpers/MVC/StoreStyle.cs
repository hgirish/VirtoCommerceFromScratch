using System.Linq;
using System.Web;
using System.Web.Optimization;
using CommerceWebClient;

namespace StoreWebApp.Virto.Helpers.MVC
{
    public static  class StoreStyle
    {
        /// <summary>
        /// Renders the styles for current store using specified path format.
        /// </summary>
        /// <param name="pathFormat">The path format.</param>
        /// <returns></returns>
        public static IHtmlString Render(params string[] pathFormat)
        {
            var validPaths = from path in pathFormat
                             select string.Format(path, StoreHelper.CustomerSession.StoreId)
                                 into formatedPath
                                 let bundle = BundleTable.Bundles.GetBundleFor(formatedPath)
                                 where bundle != null
                                 select formatedPath;

            return Styles.Render(validPaths.ToArray());
        }
    }
}