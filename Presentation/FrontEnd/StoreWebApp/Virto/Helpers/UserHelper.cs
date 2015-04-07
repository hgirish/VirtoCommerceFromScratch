using System.Web.Mvc;
using CommerceClient;
using CommerceFoundation;
using CommerceFoundation.Customers.Services;

namespace StoreWebApp.Virto.Helpers
{
    public class UserHelper
    {
        public static ICustomerSession CustomerSession
        {
            get
            {
                var session = DependencyResolver.Current.GetService<ICustomerSessionService>();
                return session.CustomerSession;
            }
        }

        public static StoreClient StoreClient
        {
            get { return DependencyResolver.Current.GetService<StoreClient>(); }
        }
    }
}