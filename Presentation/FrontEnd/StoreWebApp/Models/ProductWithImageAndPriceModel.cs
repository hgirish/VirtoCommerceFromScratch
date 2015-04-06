using System;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class ProductWithImageAndPriceModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductWithImageAndPriceModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ProductWithImageAndPriceModel(DynamicContentItem item)
        {
            foreach (var prop in item.PropertyValues)
            {
                if (String.Equals(prop.Name, "ProductCode", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProductCode = prop.LongTextValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        /// <value>The product code.</value>
        public string ProductCode { get; set; }
    }
}