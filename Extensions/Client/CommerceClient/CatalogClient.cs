using System.Linq;
using CommerceFoundation;
using CommerceFoundation.Catalogs;
using CommerceFoundation.Catalogs.Model;
using CommerceFoundation.Catalogs.Repositories;
using CommerceFoundation.Customers.Services;
using CommerceFoundation.Frameworks;
using CommerceFoundation.Frameworks.Extensions;

namespace CommerceClient
{
    public class CatalogClient
    {
        public const string ItemsCodeCacheKey = "C:Isc:{0}:g:{1}";
        public const string ItemsCacheKey = "C:Is:{0}:g:{1}";

        private readonly ICustomerSessionService _customerSession;
        private readonly ICatalogRepository _catalogRepository;
        private readonly ICacheRepository _cacheRepository;

        private readonly bool _isEnabled;
        public CatalogClient(ICustomerSessionService customerSession, 
            ICatalogRepository catalogRepository, ICacheRepository cacheRepository)
        {
            _customerSession = customerSession;
            _catalogRepository = catalogRepository;
            _cacheRepository = cacheRepository;
            _isEnabled = CatalogConfiguration.Instance.Cache.IsEnabled;
        }

        public Item GetItem(string id, bool useCache = true)
        {
            return GetItem(id, ItemResponseGroups.ItemSmall, null, useCache);
        }
        public Item GetItem(string id, string catalogId, bool useCache = true)
        {
            return GetItem(id, ItemResponseGroups.ItemSmall, catalogId, useCache);
        }
        public Item GetItem(string id, ItemResponseGroups responseGroups, string catalogId,bool useCache = true, bool bycode = false)
        {
            Item[] items = bycode
                ? GetItemsByCode(new[] {id}, useCache, responseGroups)
                : GetItems(new[] {id}, useCache, responseGroups);

            if (items != null && items.Any())
            {
                if (string.IsNullOrWhiteSpace(catalogId))
                {
                    return items[0];
                }

                foreach (var item in items)
                {
                    if (item.CatalogId == catalogId)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public Item[] GetItems(string[] ids)
        {
            return GetItems(ids, true, ItemResponseGroups.ItemSmall);
        }
        public Item[] GetItems(string[] ids, bool useCache, ItemResponseGroups responseGroup)
        {
            if (ids == null || !ids.Any())
                return null;

            var query = _catalogRepository.Items.Where(x => ids.Contains(x.ItemId));
            query = IncludeGroups(query, responseGroup);

            return Helper.Get(
                CacheHelper.CreateCacheKey(Constants.CatalogCachePrefix, string.Format(ItemsCacheKey, CacheHelper.CreateCacheKey(ids), responseGroup)),
                () => (query).ToArray(),
                CatalogConfiguration.Instance.Cache.ItemTimeout,
                _isEnabled && useCache);
        }
        private Item[] GetItemsByCode(string[] codes, bool useCache, ItemResponseGroups responseGroups)
        {
            if (codes == null || !codes.Any())
            {
                return null;
            }
            var query = _catalogRepository.Items.Where(x => codes.Contains(x.Code));

            query = IncludeGroups(query, responseGroups);

            return Helper.Get(
                CacheHelper.CreateCacheKey(Constants.CatalogCachePrefix, string.Format(ItemsCodeCacheKey, CacheHelper.CreateCacheKey(codes), responseGroups)),
                () => (query).ToArray(),
                CatalogConfiguration.Instance.Cache.ItemTimeout,
                _isEnabled && useCache);
        }
        CacheHelper _cacheHelper;


        public CacheHelper Helper
        {
            get { return _cacheHelper ?? (_cacheHelper = new CacheHelper(_cacheRepository)); }
        }
        private IQueryable<Item> IncludeGroups(IQueryable<Item> query, ItemResponseGroups responseGroups)
        {
            //if (responseGroups.HasFlag(ItemResponseGroups.ItemAssets))
            //{
            //    query = query.Expand(p => p.ItemAssets);
            //}

            //if (responseGroups.HasFlag(ItemResponseGroups.ItemAssociations))
            //{
            //    query = query.Expand(p => p.AssociationGroups.Select(a => a.Associations.Select(s => s.CatalogItem)));
            //}

            //if (responseGroups.HasFlag(ItemResponseGroups.ItemCategories))
            //{
            //    query = query.Expand(p => p.CategoryItemRelations);
            //}

            //if (responseGroups.HasFlag(ItemResponseGroups.ItemEditorialReviews))
            //{
            //    query = query.Expand(p => p.EditorialReviews);
            //}

            //if (responseGroups.HasFlag(ItemResponseGroups.ItemProperties))
            //{
            //    query = query.Expand(p => p.ItemPropertyValues);
            //}

            return query;
        }
        public PropertySet GetPropertySet(string propertySetId)
        {
            throw new System.NotImplementedException();
        }

        public ItemAvailability GetItemAvailability(string itemId, string fulfillmentCenter)
        {
            throw new System.NotImplementedException();
        }

        public ICustomerSession CustomerSession
        {
            get
            {
                return _customerSession.CustomerSession;
            }
        }
    }
}