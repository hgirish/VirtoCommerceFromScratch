using CommerceClient;
using CommerceFoundation;
using CommerceFoundation.Customers.Services;
using Microsoft.Practices.ServiceLocation;

namespace CommerceWebClient
{
    public class StoreHelper
    {
        public static ICustomerSession CustomerSession
        {
            get
            {
                var session = ServiceLocator.Current.GetInstance<ICustomerSessionService>();
                return session.CustomerSession;
            }
        }

        public static StoreClient StoreClient
        {
            get { return ServiceLocator.Current.GetInstance<StoreClient>(); }
        }
    }
}
