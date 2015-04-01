using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity.Mvc;

namespace CommerceWebClient
{
    public class UnityDependencyResolverServiceLocatorProvider : ServiceLocatorImplBase
    {
        private readonly UnityDependencyResolver _unityDependencyResolver;

        public UnityDependencyResolverServiceLocatorProvider(UnityDependencyResolver unityDependencyResolver)
        {
            _unityDependencyResolver = unityDependencyResolver;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return _unityDependencyResolver.GetService(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _unityDependencyResolver.GetServices(serviceType);
        }
    }
}