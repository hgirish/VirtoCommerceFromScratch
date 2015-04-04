using System;
using System.Configuration;
using System.Threading;

namespace CommerceFoundation.Marketing
{
    public class DynamicContentConfiguration : ConfigurationSection
    {
        private static Lazy<DynamicContentConfiguration> _instance = 
            new Lazy<DynamicContentConfiguration>(CreateInstance, 
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static DynamicContentConfiguration CreateInstance()
        {
            return (DynamicContentConfiguration) ConfigurationManager
                .GetSection("VirtoCommerce/DynamicContent");
        }

        public static DynamicContentConfiguration Instance
        {
            get { return _instance.Value; }
        }

        [ConfigurationProperty("Cache", IsRequired = true)]
        public CacheConfiguration Cache
        {
            get
            {
                return (CacheConfiguration)this["Cache"];
            }
        }
    }
}