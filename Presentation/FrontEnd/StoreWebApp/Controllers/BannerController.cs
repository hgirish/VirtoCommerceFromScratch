using System.Linq;
using System.Web.Mvc;
using CommerceClient;
using StoreWebApp.Models;

namespace StoreWebApp.Controllers
{
    public class BannerController : ControllerBase
    {
        private readonly DynamicContentClient _contentHelper;

        public BannerController()
        {
            
        }
        public BannerController(DynamicContentClient contentHelper)
        {
            _contentHelper = contentHelper;
        }

        public ActionResult ShowDynamicContent(string placeName)
        {
            var items = _contentHelper.GetDynamicContent(placeName);
            if (items != null && items.Any())
            {
                return PartialView("BaseContentPlace",
                    new BannerModel(items));
            }
            return null;
        }
    }
}