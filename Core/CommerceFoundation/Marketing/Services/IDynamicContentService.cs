using System;
using CommerceFoundation.Frameworks.Tagging;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace CommerceFoundation.Marketing.Services
{
    public interface IDynamicContentService
    {
        DynamicContentItem[] GetItems(string placeId, DateTime now, TagSet tags);
    }
}