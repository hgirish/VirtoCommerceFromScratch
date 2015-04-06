using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public class DynamicContentItem : StorageEntity
    {
        private string _dynamicContentItemId;
        [Key]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [DataMember]
        public string DynamicContentItemId
        {
            get { return _dynamicContentItemId; }
            set { SetValue(ref _dynamicContentItemId, () => DynamicContentItemId, value); }
        }
    }
}