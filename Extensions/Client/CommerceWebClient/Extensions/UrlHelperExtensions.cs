using System;
using System.Web.Mvc;
using System.Web.Routing;
using CommerceClient;
using CommerceFoundation.Catalogs.Model;

namespace CommerceWebClient.Extensions
{
    public static  class UrlHelperExtensions
    {
        public static CatalogClient CatalogClient
        {
            get { return DependencyResolver.Current.GetService<CatalogClient>(); }
        }

        public static string ItemUrl(this UrlHelper helper, string itemId, string parentItemId)
        {
            return helper.ItemUrl(!string.IsNullOrEmpty(itemId) ? CatalogClient.GetItem(itemId) : null,
                !string.IsNullOrEmpty(parentItemId) ? CatalogClient.GetItem(parentItemId) : null);
        }

        public static string ItemUrl(this UrlHelper helper, Item item, string parentItemId)
        {
            return helper.ItemUrl(item, !string.IsNullOrEmpty(parentItemId) ? CatalogClient.GetItem(parentItemId) : null);
        }
        public static string ItemUrl(this UrlHelper helper, Item item, Item parent)
        {
            var routeValues = new RouteValueDictionary();

            if (parent != null)
            {
                routeValues.Add("item", parent.ItemId);
                if (item != null)
                {
                    routeValues.Add("variation", item.ItemId);
                }
               // routeValues.Add("category", item.GetItemCategoryRouteValue());
            }
            else if (item != null)
            {
                routeValues.Add("item", item.ItemId);
                //routeValues.Add("category", item.GetItemCategoryRouteValue());
            }
            return helper.RouteUrl("Item", routeValues);
        }
        public static string Image(this UrlHelper helper, Item item, string name)
        {
            const string defaultImage = "blank.png";

            //if (item == null)
                return null;

           // var asset = FindItemAsset(item.ItemAssets, name);

            //return helper.Content(asset == null ? String.Format("~/Content/themes/default/images/{0}", defaultImage) : AssetUrl(asset));
        }

        //public static string Image(this UrlHelper helper, ItemAsset asset)
        //{
        //    const string defaultImage = "blank.png";

        //    return helper.Content(asset == null ? String.Format("~/Content/themes/default/images/{0}", defaultImage) : AssetUrl(asset));
        //}

    }
}