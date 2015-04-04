using System;
using System.Configuration;

namespace CommerceFoundation.Marketing
{
    public class CacheConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("enabled", IsRequired = true, DefaultValue = true)]
        public bool IsEnabled
        {
            get
            {
                return (bool)this["enabled"];
            }
            set
            {
                this["enabled"] = value;
            }
        }
        [ConfigurationProperty("dynamicContentTimeout", IsRequired = true)]
        public TimeSpan DynamicContentTimeout
        {
            get { return (TimeSpan) this["dynamicContentTimeout"]; }
            set { this["dynamicContentTimeout"] = value.ToString(); }
        }
    }
}