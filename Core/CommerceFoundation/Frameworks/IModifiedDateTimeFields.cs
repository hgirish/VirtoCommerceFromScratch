using System;

namespace CommerceFoundation.Frameworks
{
    public interface IModifiedDateTimeFields
    {
        DateTime? LastModified { get; set; }
        DateTime? Created { get; set; }
    }
}