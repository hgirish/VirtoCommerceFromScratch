using CommerceFoundation;
using CommerceFoundation.Customers.Services;
using CommerceFoundation.Frameworks;
using CommerceFoundation.Marketing;
using CommerceFoundation.Marketing.Model.DynamicContent;
using CommerceFoundation.Marketing.Services;

namespace CommerceClient
{
    public class DynamicContentClient
    {
        public const string DynamicContentCacheKey = "M:DC:S{0}:{1}:{2}";
        private readonly bool _isEnabled;
        private readonly ICustomerSessionService _customerSession;
        private readonly ICacheRepository _cacheRepository;
        private readonly IDynamicContentService _service;
        public DynamicContentClient(ICustomerSessionService customerSession, ICacheRepository cacheRepository, IDynamicContentService service)
        {
            _customerSession = customerSession;
            _cacheRepository = cacheRepository;
            _service = service;
            if (DynamicContentConfiguration.Instance != null)
                _isEnabled = DynamicContentConfiguration.Instance.Cache.IsEnabled;
        }

        public DynamicContentItem[] GetDynamicContent(string placeName)
        {
            var session = _customerSession.CustomerSession;
            var tags = session.GetCustomerTagSet();

            if (Helper != null)
                if (DynamicContentConfiguration.Instance != null)
                    return Helper.Get(
                        CacheHelper.CreateCacheKey(
                            Constants.DynamciContentCachePrefix,
                            string.Format(DynamicContentCacheKey,
                                placeName, session.CurrentDateTime, tags.GetCacheKey())),
                        () => _service.GetItems(placeName, session.CurrentDateTime, tags),
                        DynamicContentConfiguration.Instance.Cache.DynamicContentTimeout,
                        _isEnabled);
            return new DynamicContentItem[0];
        }

        CacheHelper _cacheHelper;
      
        public CacheHelper Helper
        {
            get { return _cacheHelper ?? (_cacheHelper = new CacheHelper(_cacheRepository)); }
        }
    }
}