using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CommerceFoundation.Frameworks;

namespace CommerceFoundation.Marketing.Model.DynamicContent
{
    public class DynamicContentPublishingGroup : StorageEntity
    {
        private int _priority;
        [DataMember]
        public int Priority
        {
            get { return _priority; }
            set { SetValue(ref _priority, () => Priority, value); }
        }

        private string _name;
        [DataMember]
        [Required(ErrorMessage = "Field 'Name' is required.")]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, () => Name, value); }
        }

        private DateTime? _startDate;
        [DataMember]
        public DateTime? StartDate
        {
            get { return _startDate; }
            set { SetValue(ref _startDate, () => StartDate, value); }
        }

        private DateTime? _endDate;
        [DataMember]
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { SetValue(ref _endDate, () => EndDate, value); }
        }

        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { SetValue(ref _isActive, () => IsActive, value); }
        }

        ObservableCollection<PublishingGroupContentPlace> _contentPlaces = null;
        [DataMember]
        public virtual ObservableCollection<PublishingGroupContentPlace> ContentPlaces
        {
            get
            {
                if (_contentPlaces == null)
                    _contentPlaces = new ObservableCollection<PublishingGroupContentPlace>();

                return _contentPlaces;
            }
        }
        ObservableCollection<PublishingGroupContentItem> _contentItems = null;
        [DataMember]
        public virtual ObservableCollection<PublishingGroupContentItem> ContentItems
        {
            get
            {
                if (_contentItems == null)
                    _contentItems = new ObservableCollection<PublishingGroupContentItem>();

                return _contentItems;
            }
        }

        private string _conditionExpression;
        [DataMember]
        public string ConditionExpression
        {
            get { return _conditionExpression; }
            set { SetValue(ref _conditionExpression, () => ConditionExpression, value); }
        }
    }
}