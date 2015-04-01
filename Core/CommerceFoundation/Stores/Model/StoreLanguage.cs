using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Stores.Model
{
    public class StoreLanguage : StorageEntity
    {
        private string _languageCode;

        public string LanguageCode
        {
            get { return _languageCode; }
            set
            {
                SetValue(ref _languageCode, ()=>LanguageCode, value);
            }
        }
    }
}