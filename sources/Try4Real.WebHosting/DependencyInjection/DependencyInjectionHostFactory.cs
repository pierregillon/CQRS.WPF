using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Try4Real.EndPoint.WCF.DependencyInjection
{
    public class DependencyInjectionHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new DependencyInjectionServiceHost(serviceType, baseAddresses);
        }
    }
}