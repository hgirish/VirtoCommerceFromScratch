using System;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public interface IDynamicContentEvaluationContext : IEvaluationContext
    {
        string CustomerId { get; set; }
        string ContentPlace { get; set; }
        DateTime CurrentDate { get; set; }
    }
}