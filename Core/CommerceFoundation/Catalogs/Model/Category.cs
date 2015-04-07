using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CommerceFoundation.Catalogs.Model
{
    public class Category : CategoryBase
    {
        private string _Name;
        [Required(ErrorMessage = "Field 'Category Name' is required.")]
        [DataMember]
        [StringLength(128)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetValue(ref _Name, () => this.Name, value);
            }
        }
    }
}