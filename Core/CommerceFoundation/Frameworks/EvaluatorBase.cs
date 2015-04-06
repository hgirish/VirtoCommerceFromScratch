using System;
using System.Runtime.Caching;
using System.Xml.Linq;
using ExpressionSerialization;

namespace CommerceFoundation.Frameworks
{
    public abstract  class EvaluatorBase
    {
        protected static CacheHelper Cache;
        public const string ExpressionCacheKey = "EXPR:{0}";
        private static readonly ObjectCache _memoryCache = MemoryCache.Default;


        private ExpressionSerializer _expressionSerializer;
        private ExpressionSerializer ExpressionSerializer
        {
            get
            {
                if (_expressionSerializer == null)
                {
                    var typeResolver = new TypeResolver(assemblies: AppDomain.CurrentDomain.GetAssemblies(), knownTypes: null);
                    _expressionSerializer = new ExpressionSerializer(typeResolver, null);
                }
                return _expressionSerializer;

            }
        }
        protected Func<IEvaluationContext, bool> DeserializeExpression<T>(string expression)
        {
            return GetFromCache(string.Format(ExpressionCacheKey, expression.GetHashCode()),
                                () => DeserializeExpressionNonCached<Func<IEvaluationContext, bool>>(expression));
        }

        private T GetFromCache<T>(string key, Func<T> valueFactory)
        {
            var newValue = new Lazy<T>(valueFactory);
            // the line belows returns existing item or adds the new value if it doesn't exist
            var value = _memoryCache.AddOrGetExisting(key, newValue, MemoryCache.InfiniteAbsoluteExpiration);
            return ((value ?? newValue) as Lazy<T>).Value; // Lazy<T> handles the locking itself
        }

        private T DeserializeExpressionNonCached<T>(string expression)
        {
            var xElement = XElement.Parse(expression);
            var conditionExpression = ExpressionSerializer.Deserialize<T>(xElement);
            var retVal = conditionExpression.Compile();
            return retVal;
        }
    }
}