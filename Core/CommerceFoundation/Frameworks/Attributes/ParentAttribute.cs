using System;

namespace CommerceFoundation.Frameworks.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ParentAttribute : Attribute
    {
    }
}