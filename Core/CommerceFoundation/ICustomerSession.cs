using System;
using CommerceFoundation.Frameworks.Tagging;
using CommerceFoundation.Stores;

namespace CommerceFoundation
{
    public interface ICustomerSession
    {
        string StoreId { get; set; }
        string StoreName { get; set; }
        string Currency { get; set; }
        DateTime CurrentDateTime { get; set; }
        string CatalogId { get; set; }
        object this[string key] { get; set; }
        TagSet GetCustomerTagSet();
    }
}