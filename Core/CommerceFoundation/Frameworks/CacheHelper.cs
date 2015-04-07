using System;
using System.Text;
using CommerceFoundation.Marketing.Model.DynamicContent;

namespace CommerceFoundation.Frameworks
{
    public class CacheHelper
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheHelper(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public const string GlobalCachePrefix = "_vcc@che";

        public T Get<T>(string cacheKey, 
            Func<T> fallbackFunction, TimeSpan timeSpan, 
            bool useCache=true) where T: class 
        {
            if (_cacheRepository == null || !useCache)
            {
                return fallbackFunction();
            }
            var data = _cacheRepository.Get(cacheKey);

            if (data != null)
            {
                if (data == DBNull.Value)
                {
                    return null;
                }
                return data as T;
            }
            var data2 = fallbackFunction();
            _cacheRepository.Add(cacheKey, data2 ?? (object) DBNull.Value,
                timeSpan);
            return data2;
        }

        public static string CreateCacheKey(string prefix, params string[] keys)
        {
            var returnKey = new StringBuilder(string.Concat(
                GlobalCachePrefix, prefix));
            if (keys != null)
            {
                foreach (var key in keys)
                {
                    returnKey.Append("-");
                    returnKey.Append(key);
                }
            }
            return returnKey.ToString();
        }

        public static string CreateCacheKey(params string[] keys)
        {
            var returnKey = new StringBuilder();

            if (keys != null)
                foreach (var key in keys)
                {
                    returnKey.Append("-");
                    returnKey.Append(key);
                }

            return returnKey.ToString();
        }
    }
}