using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CommerceFoundation.Frameworks.Extensions
{
    public static  class AssemblyExtensions
    {
        public static string GetInformationalVersion(this Assembly assembly)
        {
            var customAttributes = assembly.GetCustomAttributes(false);
            var assemblyInformationalVersionAttributes = customAttributes
                .OfType<AssemblyInformationalVersionAttribute>();
            var assemblyInformationalVersionAttribute = assemblyInformationalVersionAttributes
                .Single<AssemblyInformationalVersionAttribute>();
            if (assemblyInformationalVersionAttribute
                .InformationalVersion != null)
                return assemblyInformationalVersionAttribute
                    .InformationalVersion;
            return null;
        }

        public static string GetFileVersion(this Assembly assembly)
        {
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.FileBuildPart.ToString();
            return version;
        }
    }
}