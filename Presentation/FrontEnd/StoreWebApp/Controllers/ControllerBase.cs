using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommerceWebClient.Extensions;
using CommerceWebClient.Extensions.Routing.Routes;
using StoreWebApp.Models;

namespace StoreWebApp.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.Canceled && filterContext.Result != null && !ControllerContext.IsChildAction)
            {
                FillViewBagWithMetadata(filterContext);
            }

            var messages = new MessagesModel();
            var hasMessages = Enum.GetNames(typeof (MessageType)).Aggregate(false, (current, typeName) =>
            current | ProcessMessages((MessageType)Enum.Parse(typeof(MessageType), typeName), messages));
            

            if (hasMessages)
            {
                this.SharedViewBag().Messages = messages;
            }
        }

        private bool ProcessMessages(MessageType type, MessagesModel messages)
        {
            var messagesTmp = TempData[GetMessageTempKey(type)] as IEnumerable;
            var foundAny = false;
            if (messagesTmp != null)
            {
                foreach (var messageTmp in messagesTmp)
                {
                    messages.Add(new MessageModel(messageTmp.ToString(), type));
                    foundAny = true;
                }
            }
            return foundAny;
        }

        private string GetMessageTempKey(MessageType type)
        {
            return string.Format("{0}_messages", type);
        }

        private bool FillViewBagWithMetadata(ActionExecutedContext filterContext)
        {
            var storeRoute = filterContext.RouteData.Route as StoreRoute;
            if (storeRoute != null)
            {
                string routeKey = storeRoute.GetMainRouteKey();

                if (filterContext.RouteData.Values.ContainsKey(routeKey))
                {
                    var routeValue = filterContext.RouteData.Values[routeKey] as string;
                    if (!string.IsNullOrEmpty(routeValue))
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            DontCacheAjax(filterContext);
            base.OnResultExecuting(filterContext);
        }

        private void DontCacheAjax(ResultExecutingContext filterContext)
        {
            var context = filterContext.HttpContext;

            if (context.Request.RequestType != "GET" || filterContext.IsChildAction|| !context.Request.IsAjaxRequest())
            {
                return;
            }
            var cache = filterContext.HttpContext.Response.Cache;
            cache.SetExpires( DateTime.UtcNow.AddDays(-1));
            cache.SetValidUntilExpires(false);
            cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            cache.SetCacheability(HttpCacheability.NoCache);
            cache.SetNoStore();
        }
    }
}