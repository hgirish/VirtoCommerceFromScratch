using System;
using System.Linq.Expressions;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Stores
{
    public class Store : StorageEntity
    {
        private string _storeId;

        public string StoreId
        {
            get { return _storeId; }
            set { SetValue(ref _storeId, () => StoreId, value); }
        }

        


    }
}