namespace StoreWebApp.Models
{

    public  class AssociatedCatalogItemWithPriceModel : CatalogItemWithPriceModel
    {
        private readonly string _associationType;
        public AssociatedCatalogItemWithPriceModel(
            ItemModel itemModel, PriceModel priceModel,
            ItemAvailabilityModel itemAvaiability,  string associationType)
            : base(itemModel, priceModel, itemAvaiability)
        {
            _associationType = associationType;
        }
    }
}