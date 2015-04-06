using System;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class ImageNonClickableModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageNonClickableModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ImageNonClickableModel(DynamicContentItem item)
        {
            foreach (var prop in item.PropertyValues)
            {
                if (String.Equals(prop.Name, "ImageFilePath", StringComparison.InvariantCultureIgnoreCase))
                {
                    ImageUrl = prop.LongTextValue;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl { get; set; }
    }
}