using System.Linq;
using CommerceFoundation.Catalogs.Model;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Catalogs.Repositories
{
    public interface ICatalogRepository : IRepository
    {
        IQueryable<Item> Items { get; }
    }
}