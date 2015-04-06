using System;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public sealed  class DynamicContentEvaluationContext : BaseEvaluationContext, IDynamicContentEvaluationContext
    {
        public string CustomerId { get; set; }
        public DateTime CurrentDate { get; set; }
        public string ContentPlace { get; set; }
    }
}