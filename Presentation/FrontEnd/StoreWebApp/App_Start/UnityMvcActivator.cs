using System.Linq;
using System.Web.Mvc;
using CommerceWebClient;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity.Mvc;
using StoreWebApp;
using StoreWebApp.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityWebActivator), "Shutdown")]

namespace StoreWebApp
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            var dependencyResolver = new UnityDependencyResolver(container);
            var locatorProvider = new UnityDependencyResolverServiceLocatorProvider(dependencyResolver);
            ServiceLocator.SetLocatorProvider(() => locatorProvider);
            DependencyResolver.SetResolver(dependencyResolver);

               
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}