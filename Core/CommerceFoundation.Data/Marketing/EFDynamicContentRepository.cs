using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using CommerceFoundation.Data.Infrastructure;
using CommerceFoundation.Data.Infrastructure.Interceptors;
using CommerceFoundation.Marketing.Model.DynamicContent;
using CommerceFoundation.Marketing.Repositories;

namespace CommerceFoundation.Data.Marketing
{
    public class EfDynamicContentRepository : EfRepositoryBase, IDynamicContentRepository
    {
        // public EfDynamicContentRepository() : this("VirtoCommerce")
        //{
        //}
        // public EfDynamicContentRepository(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //    Configuration.AutoDetectChangesEnabled = true;
        //    Configuration.ProxyCreationEnabled = false;
        //   // Database.SetInitializer<EfDynamicContentRepository>(null);
        //}
        public IQueryable<DynamicContentItem> Items
        {
            get { return GetAsQueryable<DynamicContentItem>(); }
        }

        public IQueryable<DynamicContentPublishingGroup> PublishingGroups
        {
            get { return GetAsQueryable<DynamicContentPublishingGroup>(); }
        }
        public IQueryable<DynamicContentPlace> Places
        {
            get { return GetAsQueryable<DynamicContentPlace>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            MapEntity<DynamicContentItem>(modelBuilder, toTable: "DynamicContentItem");
            MapEntity<DynamicContentPlace>(modelBuilder, toTable: "DynamicContentPlace");
            MapEntity<DynamicContentPublishingGroup>(modelBuilder, toTable: "DynamicContentPublishingGroup");
            MapEntity<PublishingGroupContentItem>(modelBuilder, toTable: "PublishingGroupContentItem");
            MapEntity<PublishingGroupContentPlace>(modelBuilder, toTable: "PublishingGroupContentPlace");

          //  modelBuilder.Entity<PublishingGroupContentItem>().HasRequired(p => p.ContentItem).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<PublishingGroupContentPlace>().HasRequired(p => p.ContentPlace).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }


        
    }
}