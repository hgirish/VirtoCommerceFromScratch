using System.Linq;
using CommerceFoundation.Data.Infrastructure;
using CommerceFoundation.Marketing.Model.DynamicContent;
using CommerceFoundation.Marketing.Repositories;

namespace CommerceFoundation.Data.Marketing
{
    public class EfDynamicContentRepository : EfRepositoryBase, IDynamicContentRepository
    {

        public IQueryable<DynamicContentItem> Items
        {
            get { return GetAsQueryable<DynamicContentItem>(); }
        }
    }
}