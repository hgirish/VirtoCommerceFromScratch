using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;
using CommerceFoundation.Stores.Model;

namespace CommerceFoundation.Stores
{
    public class Store : StorageEntity
    {
        private string _storeId;
        private ObservableCollection<StoreLanguage> _languages;

        public string StoreId
        {
            get { return _storeId; }
            set { SetValue(ref _storeId, () => StoreId, value); }
        }

        public ObservableCollection<StoreLanguage> Languages
        {
            get { return _languages ?? (_languages = new ObservableCollection<StoreLanguage>()); }
        }

        private string _FulfillmentCenterId;
        [DataMember]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string FulfillmentCenterId
        {
            get
            {
                return _FulfillmentCenterId;
            }
            set
            {
                SetValue(ref _FulfillmentCenterId, () => this.FulfillmentCenterId, value);
            }
        }
    }
}