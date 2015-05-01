using System;
using System.ServiceModel;

namespace CQRS.WPF.WebHosting.DependencyInjection
{
    public class DependencyInjectionServiceHost : ServiceHost
    {
        public DependencyInjectionServiceHost() : base() { }
        public DependencyInjectionServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses) { }

        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(new DependencyInjectionServiceBehavior());
            base.OnOpening();
        }
    }
}