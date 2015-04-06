using System.Configuration;

namespace CommerceFoundation.AppConfig
{
    public class AppConfigConnection : ConfigurationElement
    {
        [ConfigurationProperty("sqlConnectionStringName", IsRequired = false)]
        public string SqlConnectionStringName
        {
            get
            {
                return (string)this["sqlConnectionStringName"];
            }
            set
            {
                this["sqlConnectionStringName"] = value;
            }
        }
    }
}