using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Web.Mvc;

namespace CommerceWebClient
{
    internal sealed class PageData : DynamicObject
    {
        private readonly Func<ViewDataDictionary> _viewDataThunk;

        public PageData(Func<ViewDataDictionary> viewDataThunk)
        {
            _viewDataThunk = viewDataThunk;
        }

        private ViewDataDictionary ViewData
        {
            get
            {
                ViewDataDictionary viewData = _viewDataThunk();
                Debug.Assert(viewData != null);
                return viewData;
            }
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return ViewData.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = ViewData[binder.Name];
            // since ViewDataDictionary always returns a result even if the key does not exist, always return true
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            ViewData[binder.Name] = value;
            // you can always set a key in the dictionary so return true
            return true;
        }
    }
}