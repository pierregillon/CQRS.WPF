using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Try4Real.EndPoint.WCF.DependencyInjection
{
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        public DependencyInjectionInstanceProvider(Type serviceType) => _serviceType = serviceType;

        public object GetInstance(InstanceContext instanceContext) => GetInstance(instanceContext, null);

        public object GetInstance(InstanceContext instanceContext, Message message) => Global.CurrentDomainGate.GetService(_serviceType);

        public void ReleaseInstance(InstanceContext instanceContext, object instance) { }
    }
}