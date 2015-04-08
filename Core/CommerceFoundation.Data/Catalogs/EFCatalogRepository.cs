using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using CommerceFoundation.Catalogs.Model;
using CommerceFoundation.Catalogs.Repositories;
using CommerceFoundation.Data.Infrastructure;

namespace CommerceFoundation.Data.Catalogs
{
    public class EFCatalogRepository : EfRepositoryBase, ICatalogRepository
    {
        public IQueryable<Item> Items
        {
            get { return GetAsQueryable<Item>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            InheritanceMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void InheritanceMapping(DbModelBuilder modelBuilder)
        {
            MapEntity<Item>(modelBuilder, toTable: "Item");
        }
    }
}