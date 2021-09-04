using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Try4Real.EndPoint.WCF.DependencyInjection
{
    public class DependencyInjectionServiceBehavior : IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers) {
                var cd = cdb as ChannelDispatcher;
                if (cd != null) {
                    foreach (var ed in cd.Endpoints) {
                        ed.DispatchRuntime.InstanceProvider = new DependencyInjectionInstanceProvider(serviceDescription.ServiceType);
                    }
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
}