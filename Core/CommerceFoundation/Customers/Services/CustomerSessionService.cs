using System.Threading;
using System.Web;

namespace CommerceFoundation.Customers.Services
{
   public class CustomerSessionService : ICustomerSessionService
    {
       private const string SessionKey = "v-customersession";

       public ICustomerSession CustomerSession
       {
           get
           {
               var key = SessionKey;
               if (HttpContext.Current == null)
               {
                   var ctxThread =
                       Thread.GetData(Thread.GetNamedDataSlot(key));
                   if (ctxThread != null)
                   {
                       return (CustomerSession) ctxThread;
                   }
                   var ctx = new CustomerSession();
                   Thread.SetData(Thread.GetNamedDataSlot(key), ctx);
                   return ctx;
               }
               if (HttpContext.Current.Items[key] == null)
               {
                   var ctx = new CustomerSession();
                   HttpContext.Current.Items.Add(key, ctx);
                   return ctx;
               }
               return (CustomerSession) HttpContext.Current.Items[key];
           }
       }
    }
}