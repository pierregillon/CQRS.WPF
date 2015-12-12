using SimpleInjector;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.EndPoint;

namespace Try4Real.Client.Wpf.LocalDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService(Container clientContainer)
        {
            var domainEntry = new DomainGate();

            clientContainer.RegisterSingleton(domainEntry.CustomerService);
            clientContainer.RegisterSingleton(domainEntry.OrderService);
            clientContainer.RegisterSingleton(domainEntry.ProductService);
        }
    }
}