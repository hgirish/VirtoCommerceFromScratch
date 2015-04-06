using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Services.Common;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    [DataContract]
    [EntitySet("PublishingGroupContentPlaces")]
    [DataServiceKey("PublishingGroupContentPlaceId")]
    public class PublishingGroupContentPlace : StorageEntity
    {
        public PublishingGroupContentPlace()
        {
            _publishingGroupContentPlaceId = GenerateNewKey();
        }

        private string _publishingGroupContentPlaceId;
        [Key]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [DataMember]
        public string PublishingGroupContentPlaceId
        {
            get
            {
                return _publishingGroupContentPlaceId;
            }
            set
            {
                SetValue(ref _publishingGroupContentPlaceId, () => this.PublishingGroupContentPlaceId, value);
            }
        }

        private string _PublishingGroupId;
        [DataMember]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [ForeignKey("PublishingGroup")]
        [Required]
        public string DynamicContentPublishingGroupId
        {
            get
            {
                return _PublishingGroupId;
            }
            set
            {
                SetValue(ref _PublishingGroupId, () => this.DynamicContentPublishingGroupId, value);
            }
        }

        private string _ContentPlaceId;
        [DataMember]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [ForeignKey("ContentPlace")]
        [Required]
        public string DynamicContentPlaceId
        {
            get
            {
                return _ContentPlaceId;
            }
            set
            {
                SetValue(ref _ContentPlaceId, () => this.DynamicContentPlaceId, value);
            }
        }
        public virtual DynamicContentPlace ContentPlace { get; set; }
        [DataMember]
        public virtual DynamicContentPublishingGroup PublishingGroup { get; set; }
    }
}