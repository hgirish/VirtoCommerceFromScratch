using System;
using CommerceFoundation.Frameworks.Tagging;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace CommerceFoundation.Marketing.Services
{
    public  class DynamicContentService : IDynamicContentService
    {
       // private IDynamicContentRepository _repository;
       // private readonly IDynamicContentEvaluator _evaluator;

        public DynamicContentItem[] GetItems(string placeId, DateTime now, TagSet tags)
        {
            return null;
        }
    }
}