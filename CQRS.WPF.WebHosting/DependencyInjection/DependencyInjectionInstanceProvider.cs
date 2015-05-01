using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using CQRS.WPF.EndPoint;

namespace CQRS.WPF.WebHosting.DependencyInjection
{
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        public DependencyInjectionInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return Ioc.Instance.GetInstance(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance) { }
    }
}