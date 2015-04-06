using System;
using System.Linq;
using System.Web.Mvc;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class RazorHtmlModel : RawHtmlModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RawHtmlModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context"></param>
        public RazorHtmlModel(DynamicContentItem item, ViewContext context)
            : base(item)
        {
            if (string.IsNullOrWhiteSpace(Html))
            {
                foreach (
                    var prop in
                        item.PropertyValues.Where(
                            prop => String.Equals(prop.Name, "RazorHtml", StringComparison.InvariantCultureIgnoreCase)))
                {
                    Html = prop.LongTextValue;
                    break;
                }
            }
            Html = "RazorHTML";
            //Html = ViewRenderer.RenderTemplate(Html, this, context.Controller.ControllerContext);
        }
    }
}