using System.Web.Mvc;
using CommerceClient;
using StoreWebApp.Models;
using StoreWebApp.Virto.Helpers;

namespace StoreWebApp.Controllers
{

    public class CatalogController : ControllerBase
    {
        private readonly CatalogClient _catalogClient;

        public CatalogController(CatalogClient catalogClient)
        {
            _catalogClient = catalogClient;
        }

        public ActionResult DisplayItemNoCache(string itemId,
           string parentItemId = null,
           string name = "MiniItem",
           string associationType = null,
           bool forcedActive = false,
           ItemResponseGroups responseGroups = ItemResponseGroups.ItemSmall,
           ItemDisplayOptions displayOptions = ItemDisplayOptions.ItemSmall,
           bool bycode = false)
        {
            var itemModel = CatalogHelper.CreateCatalogModel(itemId, parentItemId, associationType, forcedActive, responseGroups, displayOptions, bycode);
            return itemModel != null ? PartialView(name, itemModel) : null;
        }
    }
}