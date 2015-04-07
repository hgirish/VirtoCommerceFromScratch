using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Catalogs.Model
{
    public abstract  class Item : StorageEntity
    {
        private bool _IsActive;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetValue(ref _IsActive, () => this.IsActive, value);
            }
        }

        private string _PropertySetId;
        [DataMember]
        [StringLength(128)]
        public string PropertySetId
        {
            get
            {
                return _PropertySetId;
            }
            set
            {
                SetValue(ref _PropertySetId, () => this.PropertySetId, value);
            }
        }

        private string _ItemId;
        [Key]
        [StringLength(128)]
        [DataMember]
        public string ItemId
        {
            get
            {
                return _ItemId;
            }
            set
            {
                SetValue(ref _ItemId, () => this.ItemId, value);
            }
        }

        private string _CatalogId;
        [DataMember]
        [StringLength(128)]
        public string CatalogId
        {
            get
            {
                return _CatalogId;
            }
            set
            {
                SetValue(ref _CatalogId, () => this.CatalogId, value);
            }
        }

        private string _Code;
        [DataMember]
        [StringLength(64)]
        [Required]
        [CustomValidation(typeof(Item), "ValidateItemCode", ErrorMessage = @"Code can't contain $+;=%{}[]|\/@ ~#!^*&()?:'<>, characters")]
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                SetValue(ref _Code, () => this.Code, value);
            }
        }
    }
}