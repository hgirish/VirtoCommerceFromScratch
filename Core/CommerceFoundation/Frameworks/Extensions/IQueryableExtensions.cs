using System;
using System.Data.Entity;
using System.Data.Services.Client;
using System.Linq;
using System.Linq.Expressions;

namespace CommerceFoundation.Frameworks.Extensions
{
    public static  class  IQueryableExtensions
    {
        public static IQueryable<TEntity> Expand<TEntity>(this IQueryable<TEntity> queryable, string path)
           where TEntity : class
        {
            var objectQuery = queryable as DataServiceQuery<TEntity>;
            if (objectQuery != null) //Is DataServiceQuery
            {
                return ((DataServiceQuery<TEntity>)objectQuery).Expand(path);
            }
            else // probably mock
            {
                path = path.Replace('/', '.');
                queryable = queryable.Include(path);
                return queryable;
            }
        }
        public static IQueryable<TEntity> Expand<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            if (queryable is DataServiceQuery<TEntity>)
            {
                queryable = includes.Aggregate(queryable,
                              (current, include) => ((DataServiceQuery<TEntity>)current).Expand(include));
            }
            else
            {
                if (includes != null)
                {
                    queryable = includes.Aggregate(queryable,
                              (current, include) => current.Include(include));
                }

            }
            return queryable;
        }
    }
}