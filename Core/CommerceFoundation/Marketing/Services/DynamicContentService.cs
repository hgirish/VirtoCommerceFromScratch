using System;
using CommerceFoundation.Frameworks.Tagging;
using CommerceFoundation.Marketing.Model.DynamicContent;
using CommerceFoundation.Marketing.Repositories;

namespace CommerceFoundation.Marketing.Services
{
    public  class DynamicContentService : IDynamicContentService
    {
       private IDynamicContentRepository _repository;
        private readonly IDynamicContentEvaluator _evaluator;
        public DynamicContentService(IDynamicContentRepository repository, IDynamicContentEvaluator evaluator)
        {
            _repository = repository;
            _evaluator = evaluator;
        }


        public DynamicContentItem[] GetItems(string placeId, DateTime now, TagSet tags)
        {
            return _evaluator.Evaluate(
                new DynamicContentEvaluationContext
                {
                    CurrentDate = now, 
                    ContentPlace = placeId, 
                    ContextObject = tags
                });
        }
    }
}