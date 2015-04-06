using System;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class ImageClickableModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageClickableModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ImageClickableModel(DynamicContentItem item)
        {
            foreach (var prop in item.PropertyValues)
            {
                if (String.Equals(prop.Name, "ImageUrl", StringComparison.InvariantCultureIgnoreCase))
                {
                    ImageUrl = prop.LongTextValue;
                }

                if (String.Equals(prop.Name, "TargetUrl", StringComparison.InvariantCultureIgnoreCase))
                {
                    TargetUrl = prop.LongTextValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the target URL.
        /// </summary>
        /// <value>The target URL.</value>
        public string TargetUrl { get; set; }
    }
}