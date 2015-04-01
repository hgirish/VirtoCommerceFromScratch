using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CommerceFoundation.Customers.Services;
using CommerceFoundation.Frameworks;
using CommerceFoundation.Stores;

namespace CommerceClient
{
    public class StoreClient
    {
        private readonly ICustomerSessionService _customerSession;

        public StoreClient(ICustomerSessionService customerSession)
        {
            _customerSession = customerSession;
        }

        public Store GetCurrentStore()
        {
            var session = _customerSession.CustomerSession;

            var storeObject = session["store"];
            if (storeObject != null)
            {
                return storeObject as Store;
            }
            var store = GetStoreById(session.StoreId);
            session["store"] = store;
            return store;
        }

        private Store GetStoreById(string storeId)
        {
            var allStores = GetStores();
            return
                allStores.Where(x => x.StoreId.Equals(storeId, StringComparison.OrdinalIgnoreCase) || storeId == "")
                    .FirstOrDefault();
        }

        private Store[] GetStores()
        {
            return new Store[0];
        }

        CacheHelper _cacheHelper;
        //public CacheHelper Helper
        //{
        //    get { return _cacheHelper ?? (_cacheHelper = new CacheHelper(_cacheRepository)); }
        //}
    }
}
