using System;
using System.Collections;
using CommerceFoundation.Frameworks.Tagging;

namespace CommerceFoundation
{
   public class CustomerSession : ICustomerSession
    {
       readonly TagSet _set = new TagSet();

       public string StoreId { get; set; }
       public string Currency { get; set; }

       DateTime _currentDateTime = DateTime.UtcNow;

     
       public DateTime CurrentDateTime
       {
           get
           {
               return _currentDateTime;
           }
           set
           {
               _currentDateTime = value;
           }
       }

       public string CatalogId { get; set; }

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

       public TagSet GetCustomerTagSet()
       {
           return _set;
       }

       public string StoreName { get; set; }

    }
}