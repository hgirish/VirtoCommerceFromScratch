using System;
using System.Web;
using System.Web.Caching;
using CommerceFoundation.Frameworks;

namespace HttpCache
{
    public class HttpCacheRepository : ICacheRepository
    {
        private readonly object _lock = new object();
        private object _cache;

        public object Get(string key)
        {
            var cache = GetCache();
            return cache.Get(key);
        }

        private Cache GetCache()
        {
            if (_cache != null)
            {
                return _cache as Cache;
            }
            lock (_lock)
            {
                if (_cache != null)
                {
                    return _cache as Cache;
                }
                var context = HttpContext.Current;
                _cache = context != null
                    ? context.Cache
                    : HttpRuntime.Cache;
            }
            return _cache as Cache;
        }

        public void Add(string key, object value, TimeSpan timeSpan)
        {
            var cache = GetCache();
            cache.Insert(key, value);
        }
    }
}
