using System.ComponentModel.DataAnnotations;
using System.Data.Services.Common;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    [DataContract]
    [EntitySet("DynamicContentPlaces")]
    [DataServiceKey("DynamicContentPlaceId")]
    public class DynamicContentPlace : StorageEntity
    {
        public DynamicContentPlace()
        {
            _dynamicContentPlaceId = GenerateNewKey();
        }
        private string _name;
        [DataMember]
        [Required]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, () => Name, value); }
        }

        private string _dynamicContentPlaceId;
        [Key]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [DataMember]
        public string DynamicContentPlaceId
        {
            get { return _dynamicContentPlaceId; }
            set { SetValue(ref _dynamicContentPlaceId, () => DynamicContentPlaceId, value); }
        }
    }
}