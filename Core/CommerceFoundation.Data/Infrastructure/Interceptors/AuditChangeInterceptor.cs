using System;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Data.Infrastructure.Interceptors
{
    public class AuditChangeInterceptor : ChangeInterceptor<IModifiedDateTimeFields>
    {
        public AuditChangeInterceptor(Type targetType) : base(targetType)
        {
        }
    }
}