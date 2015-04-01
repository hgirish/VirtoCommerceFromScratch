using System.Collections;

namespace CommerceFoundation
{
   public class CustomerSession : ICustomerSession
    {
       public string StoreId { get; set; }
       public string Currency { get; set; }

       readonly Hashtable _hash = new Hashtable();
       /// <summary>
       /// Gets or sets the <see cref="System.Object"/> with the specified key.
       /// </summary>
       /// <param name="key">The key.</param>
       /// <returns>System.Object.</returns>
       public object this[string key]
       {
           get
           {
               return _hash[key];
           }
           set
           {
               _hash[key] = value;
           }
       }

       public string StoreName { get; set; }

    }
}