using SimpleInjector;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.RemoteDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService(Container clientContainer)
        {
            clientContainer.RegisterSingleton<ICustomerService, CustomerServiceClient>();
            clientContainer.RegisterSingleton<IOrderService, OrderServiceClient>();
            clientContainer.RegisterSingleton<IProductService, ProductServiceClient>();
        }
    }
}