using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public class DynamicContentPlace : StorageEntity
    {
        private string _name;
        [DataMember]
        [Required]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, () => Name, value); }
        }
    }
}