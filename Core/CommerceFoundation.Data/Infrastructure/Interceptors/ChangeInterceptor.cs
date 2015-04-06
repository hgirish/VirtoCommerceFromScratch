using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CommerceFoundation.Data.Infrastructure.Interceptors
{
    public class ChangeInterceptor<T> : TypeInterceptor
    {
        public ChangeInterceptor(Type targetType) : base(targetType)
        {
        }

        protected override void OnBefore(DbEntityEntry item)
        {
            
        }

        protected override void OnAfter(DbEntityEntry item, EntityState state)
        {
            
        }
    }
}