using System.Web.Routing;

namespace CommerceWebClient.Extensions.Routing.Routes
{
    public class StoreRoute : Route
    {
        public StoreRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public StoreRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public StoreRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public StoreRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public string GetMainRouteKey()
        {
            return Constants.Store;
        }
    }
}