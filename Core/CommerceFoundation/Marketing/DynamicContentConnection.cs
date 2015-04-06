using System.Configuration;

namespace CommerceFoundation.Marketing
{
    public class DynamicContentConnection : ConfigurationElement
    {
        [ConfigurationProperty("wsEndPointName", IsRequired = false)]
        public string WSEndPointName
        {
            get
            {
                return (string)this["wsEndPointName"];
            }
            set
            {
                this["wsEndPointName"] = value;
            }
        }
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


        [ConfigurationProperty("dataServiceUri", IsRequired = false)]
        public string DataServiceUri
        {
            get
            {
                return (string)this["dataServiceUri"];
            }
            set
            {
                this["dataServiceUri"] = value;
            }
        }

    }
}