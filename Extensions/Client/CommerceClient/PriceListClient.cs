using CommerceFoundation.Catalogs.Model;
using CommerceFoundation.Customers.Services;

namespace CommerceClient
{
    public class PriceListClient
    {
        private readonly ICustomerSessionService _customerSession;

        public PriceListClient(ICustomerSessionService customerSession)
        {
            _customerSession = customerSession;
        }

        public Price GetLowestPrice(string itemId, int quantity)
        {
            var session = _customerSession.CustomerSession;
            // TODO
            return null;
        }
    }
}