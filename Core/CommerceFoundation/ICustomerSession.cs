using CommerceFoundation.Stores;

namespace CommerceFoundation
{
    public interface ICustomerSession
    {
        string StoreId { get; set; }
        string StoreName { get; set; }
        string Currency { get; set; }
        object this[string key] { get; set; }
    }
}