using System;
using CommerceFoundation.Catalogs.Model;
using CommerceFoundation.Catalogs.Services;

namespace StoreWebApp.Models
{
    public class ItemModel
    {
        
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>The item identifier.</value>
        public string ItemId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        /// <value>The name.</value>
        public string CategoryName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime? EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is buyable.
        /// </summary>
        /// <value><c>true</c> if this instance is buyable; otherwise, <c>false</c>.</value>
        public bool IsBuyable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [track inventory].
        /// </summary>
        /// <value><c>true</c> if [track inventory]; otherwise, <c>false</c>.</value>
        public bool TrackInventory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public decimal Weight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the package.
        /// </summary>
        /// <value>The type of the package.</value>
        public string PackageType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tax category.
        /// </summary>
        /// <value>The tax category.</value>
        public string TaxCategory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parent item identifier.
        /// </summary>
        /// <value>The parent item identifier.</value>
        public string ParentItemId { get; set; }

        public CatalogOutlines CatalogOutlines { get; set; }
        public Item Item { get; set; }
    }
}