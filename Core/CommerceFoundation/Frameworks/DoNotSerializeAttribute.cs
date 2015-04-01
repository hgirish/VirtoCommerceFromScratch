using System;

namespace CommerceFoundation.Frameworks
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DoNotSerializeAttribute : Attribute
    {
    }
}