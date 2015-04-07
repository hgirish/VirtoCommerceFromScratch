using System;
using CommerceClient;
using CommerceClient.Globalization;
using CommerceFoundation.Customers.Services;
using CommerceFoundation.Data.Marketing;
using CommerceFoundation.Frameworks;
using CommerceFoundation.Marketing.Model.DynamicContent;
using CommerceFoundation.Marketing.Repositories;
using CommerceFoundation.Marketing.Services;
using HttpCache;
using Microsoft.Practices.Unity;

namespace StoreWebApp.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<DynamicContentClient>();
            container.RegisterType<CatalogClient>();

            container.RegisterType<ICustomerSessionService, CustomerSessionService>();
            container.RegisterType<IElementRepository, DatabaseElementRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ICacheRepository, HttpCacheRepository>();
            container.RegisterType<IDynamicContentService, DynamicContentService>();


            container.RegisterType<IDynamicContentService, DynamicContentService>();
            container.RegisterType<IDynamicContentRepository, EfDynamicContentRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IDynamicContentEvaluator, DynamicContentEvaluator>();

            MvcSiteMapProviderConfig.Register(container);
        }
    }
}
