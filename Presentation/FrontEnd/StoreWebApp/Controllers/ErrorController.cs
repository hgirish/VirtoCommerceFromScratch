using System.Web.Mvc;

namespace StoreWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Oops");
        }

        public ActionResult Oops()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult FailWhale()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult StoreClosed()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}