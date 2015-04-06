using System;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class FlashModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlashModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public FlashModel(DynamicContentItem item)
        {
            foreach (var prop in item.PropertyValues)
            {
                if (String.Equals(prop.Name, "Height", StringComparison.InvariantCultureIgnoreCase))
                {
                    Height = prop.IntegerValue;
                }

                if (String.Equals(prop.Name, "Width", StringComparison.InvariantCultureIgnoreCase))
                {
                    Width = prop.IntegerValue;
                }

                if (String.Equals(prop.Name, "ClassId", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClassId = prop.LongTextValue;
                }

                if (String.Equals(prop.Name, "Src", StringComparison.InvariantCultureIgnoreCase))
                {
                    Src = prop.LongTextValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        public string ClassId { get; set; }
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Src { get; set; }
    }
}