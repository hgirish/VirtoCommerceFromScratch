using System.Web.Mvc;

namespace StoreWebApp.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}