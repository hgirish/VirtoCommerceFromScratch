using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public class PublishingGroupContentItem : StorageEntity
    {
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
    }
}