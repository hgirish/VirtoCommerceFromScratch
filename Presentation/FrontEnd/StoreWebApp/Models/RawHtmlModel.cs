using System;
using System.Linq;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class RawHtmlModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RawHtmlModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public RawHtmlModel(DynamicContentItem item)
        {
            foreach (var prop in item.PropertyValues.Where(prop => String.Equals(prop.Name, "RawHtml", StringComparison.InvariantCultureIgnoreCase)))
            {
                Html = prop.LongTextValue;
                break;
            }
        }

        /// <summary>
        /// Gets or sets the HTML.
        /// </summary>
        /// <value>The HTML.</value>
        public string Html { get; set; }
    }
}