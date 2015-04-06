using System;
using System.Configuration;
using System.Threading;

namespace CommerceFoundation.AppConfig
{
    public class AppConfigConfiguration : ConfigurationSection
    {
        private static readonly Lazy<AppConfigConfiguration> _instance = new Lazy<AppConfigConfiguration>(CreateInstance, LazyThreadSafetyMode.ExecutionAndPublication);

        public const string SectionName = "VirtoCommerce/AppConfig";

        public static AppConfigConfiguration Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static AppConfigConfiguration CreateInstance()
        {

            return (AppConfigConfiguration)ConfigurationManager.GetSection(SectionName);
        }

        [ConfigurationProperty("Connection", IsRequired = true)]
        public AppConfigConnection Connection
        {
            get
            {
                return (AppConfigConnection)this["Connection"];
            }
        }
    }
}