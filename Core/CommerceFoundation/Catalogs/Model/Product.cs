using System.Data.Services.Common;
using System.Runtime.Serialization;
using System.Threading;

namespace CommerceFoundation.Catalogs.Model
{
    [DataContract]
    [EntitySet("Items")]
    public class Product : Item
    {
        public Product() : base()
        {
            
        }
    }
}