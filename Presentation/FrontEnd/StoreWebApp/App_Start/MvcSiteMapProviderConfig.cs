using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using MvcSiteMapProvider.Loader;
using MvcSiteMapProvider.Web.Mvc;
using MvcSiteMapProvider.Xml;
using StoreWebApp.DI.Unity.ContainerExtensions;

namespace StoreWebApp
{
    public class MvcSiteMapProviderConfig
    {
        public static void Register(IUnityContainer container)
        {
            // Add the extension module (required)
            container.AddNewExtension<MvcSiteMapProviderContainerExtension>();

            // Setup global sitemap loader (required)
            MvcSiteMapProvider.SiteMaps.Loader = container.Resolve<ISiteMapLoader>();

            // Check all configured .sitemap files to ensure they follow the XSD for MvcSiteMapProvider (optional)
            var validator = container.Resolve<ISiteMapXmlValidator>();
            validator.ValidateXml(HostingEnvironment.MapPath("~/Mvc.sitemap"));

            // Register the Sitemaps routes for search engines (optional)
            XmlSiteMapController.RegisterRoutes(RouteTable.Routes);
        } 
    }
}