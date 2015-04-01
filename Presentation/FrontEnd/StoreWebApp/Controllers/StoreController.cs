using System.Web.Mvc;
using CommerceClient;

namespace StoreWebApp.Controllers
{
    public class StoreController : ControllerBase
    {
        private readonly StoreClient _storeClient;

        public StoreController(StoreClient storeClient)
        {
            _storeClient = storeClient;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }
    }
}