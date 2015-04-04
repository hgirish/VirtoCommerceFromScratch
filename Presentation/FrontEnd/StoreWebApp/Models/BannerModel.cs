using CommerceFoundation.Marketing.Model.DynamicContent;

namespace StoreWebApp.Models
{
    public class BannerModel
    {
        public BannerModel(DynamicContentItem[] items)
        {
            Items = items;
        }

        
        public DynamicContentItem[] Items { get; set; }
    }
}