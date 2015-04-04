using System;

namespace CommerceFoundation.Frameworks
{
    public interface ICacheRepository
    {
        object Get(string key);
        void Add(string key, object value, TimeSpan timeSpan);
    }
}