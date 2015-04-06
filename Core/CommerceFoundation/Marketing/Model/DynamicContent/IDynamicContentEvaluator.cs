namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public interface IDynamicContentEvaluator
    {
        DynamicContentItem[] Evaluate(IDynamicContentEvaluationContext context);
    }
}