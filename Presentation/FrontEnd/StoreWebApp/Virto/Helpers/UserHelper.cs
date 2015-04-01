using System.Web.Mvc;
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
    }
}