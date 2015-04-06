using System;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class CategoryUrlModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryUrlModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public CategoryUrlModel(DynamicContentItem item)
        {
            foreach (var prop in item.PropertyValues)
            {
                if (String.Equals(prop.Name, "CategoryCode", StringComparison.InvariantCultureIgnoreCase))
                {
                    CategoryCode = prop.LongTextValue;
                }

                if (String.Equals(prop.Name, "Title", StringComparison.InvariantCultureIgnoreCase))
                {
                    Title = prop.LongTextValue;
                }

                if (String.Equals(prop.Name, "SortField", StringComparison.InvariantCultureIgnoreCase))
                {
                    SortField = prop.ShortTextValue;
                }

                if (String.Equals(prop.Name, "ItemCount", StringComparison.InvariantCultureIgnoreCase))
                {
                    ItemCount = prop.IntegerValue;
                }

                if (String.Equals(prop.Name, "NewItems", StringComparison.InvariantCultureIgnoreCase))
                {
                    NewItemsOnly = prop.BooleanValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        /// <value>The product code.</value>
        public string CategoryCode { get; set; }

        public string SortField { get; set; }

        public int ItemCount { get; set; }

        public string Title { get; set; }

        public bool NewItemsOnly { get; set; }

    }
}