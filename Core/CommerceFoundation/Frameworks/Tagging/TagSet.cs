using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommerceFoundation.Frameworks.Tagging
{
    public class TagSet : Dictionary<string,object>
    {
        public string[] Names
        {
            get { return Keys.ToArray(); }
        }
        public string GetCacheKey()
        {
            var builder = new StringBuilder();
            foreach (var name in Names)
            {
                var value = this[name];
                builder.Append(string.Format("{0}-{1}",
                    name, value != null ? value.ToString() : string.Empty));
            }
            return builder.ToString();
        }
    }
}