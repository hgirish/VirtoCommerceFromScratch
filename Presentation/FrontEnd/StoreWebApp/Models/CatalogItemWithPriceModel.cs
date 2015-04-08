using System;
using System.Linq;

namespace StoreWebApp.Models
{
    public class CatalogItemWithPriceModel
    {
       
        private readonly ItemAvailabilityModel _availability;
        /// <summary>
        /// The _item
        /// </summary>
        private readonly ItemModel _item;
        private ItemModel itemModel;
        private PriceModel priceModel;
        private ItemAvailabilityModel itemAvaiability;

        public CatalogItemWithPriceModel(ItemModel item, PriceModel price,
            ItemAvailabilityModel availability)
        {
            _item = item;
            _price = price;
            _availability = availability;
        }
        /// <summary>
        /// The _price
    

       

        public ItemModel CatalogItem
        {
            get { return _item; }
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>The price.</value>
       

        /// <summary>
        /// Gets the availability.
        /// </summary>
        /// <value>The availability.</value>
        public ItemAvailabilityModel Availability
        {
            get { return _availability; }
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
       

        public string SearchOutline { get; set; }

        public bool IsNew { get; set; }
        public bool IsSale { get; set; }
        public string DisplayName { get; set; }
        private readonly PriceModel _price;
        public PriceModel Price
        {
            get { return _price; }
        }


        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string this[string name]
        {
            get
            {
                var firstOrDefault = _item.GetType().GetProperties().FirstOrDefault(x => x.Name == name);
                return firstOrDefault != null ? firstOrDefault.ToString() : null;
            }
        }
    }
}