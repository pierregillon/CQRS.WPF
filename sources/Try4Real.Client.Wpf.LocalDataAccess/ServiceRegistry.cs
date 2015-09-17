using SimpleInjector;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.LocalDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService(Container container)
        {
            var serverIoc = EndPoint.Ioc.Instance;
            serverIoc.Init();
            container.RegisterSingleton(serverIoc.GetInstance<ICustomerService>);
        }
    }
}