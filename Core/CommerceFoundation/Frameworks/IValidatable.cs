using System.ComponentModel;

namespace CommerceFoundation.Frameworks
{
    public interface IValidatable : IDataErrorInfo
    {
        void SetError(string propertyName, string errorMessage, bool doNotifyChanges);
        void ClearError(string propertyName);

        bool Validate(bool doNotifyChanges);
    }
}