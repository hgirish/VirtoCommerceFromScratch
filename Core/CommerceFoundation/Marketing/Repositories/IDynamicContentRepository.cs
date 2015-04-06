using System.Linq;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace CommerceFoundation.Marketing.Repositories
{
    public interface IDynamicContentRepository
    {
        IQueryable<DynamicContentItem> Items { get;  }
        IQueryable<DynamicContentPublishingGroup> PublishingGroups { get; }
        IQueryable<DynamicContentPlace> Places { get; }
    }
}