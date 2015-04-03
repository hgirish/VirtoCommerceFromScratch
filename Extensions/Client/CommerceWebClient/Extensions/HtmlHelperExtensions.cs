using System;
using System.Reflection;
using System.Web.Mvc;
using CommerceFoundation.Frameworks.Extensions;

namespace CommerceWebClient.Extensions
{
    public static  class HtmlHelperExtensions
    {
        private static MvcHtmlString _version;

        public static MvcHtmlString Version(this HtmlHelper html)
        {
            if (_version == null)
            {
                var assembly = Assembly.GetExecutingAssembly();
                _version = new MvcHtmlString(string.Format("{0} (Build {1}",
                  assembly.GetInformationalVersion(), assembly.GetFileVersion()  ));
            }
            return _version;
        }

        public static MvcHtmlString Title(this HtmlHelper htmlHelper, string title)
        {
            return MvcHtmlString.Create(htmlHelper.ViewBag.Title is string ? ((string)htmlHelper.ViewBag.Title).Title() : title.Title());

        }

        public static dynamic SharedViewBag(this HtmlHelper html)
        {
            ControllerBase controller = html.ViewContext.Controller;
            return SharedViewBag(controller);
        }

        [ThreadStatic]
        private static ControllerBase _pageDataController;
        [ThreadStatic]
        private static PageData _pageData;
        public static dynamic SharedViewBag(this ControllerBase controller)
        {
            while (controller.ControllerContext.IsChildAction)
            {
                controller = controller.ControllerContext.ParentActionViewContext.Controller;
            }
            if (_pageDataController == controller)
            {
                return _pageData;
            }
            _pageDataController = controller;
            _pageData = new PageData(() => controller.ViewData);
            return _pageData;
        }
    }
}