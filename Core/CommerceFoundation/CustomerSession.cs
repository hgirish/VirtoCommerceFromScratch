using System.Collections;

namespace CommerceFoundation
{
   public class CustomerSession : ICustomerSession
    {
       public string StoreId { get; set; }
       public string Currency { get; set; }

       readonly Hashtable _hash = new Hashtable();
    
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