using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Services.Common;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    [DataContract]
    [EntitySet("PublishingGroupContentItems")]
    [DataServiceKey("PublishingGroupContentItemId")]
    public class PublishingGroupContentItem : StorageEntity
    {
        public PublishingGroupContentItem()
        {
            _publishingGroupContentItemId = GenerateNewKey();
        }

        private string _publishingGroupContentItemId;
        [Key]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [DataMember]
        public string PublishingGroupContentItemId
        {
            get
            {
                return _publishingGroupContentItemId;
            }
            set
            {
                SetValue(ref _publishingGroupContentItemId, () => this.PublishingGroupContentItemId, value);
            }
        }

        private string _ContentItemId;
        [DataMember]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [ForeignKey("ContentItem")]
        [Required]
        public string DynamicContentItemId
        {
            get
            {
                return _ContentItemId;
            }
            set
            {
                SetValue(ref _ContentItemId, () => this.DynamicContentItemId, value);
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

        public virtual DynamicContentItem ContentItem { get; set; }
        [DataMember]
        public virtual DynamicContentPublishingGroup PublishingGroup { get; set; }
    }
}