using GalaSoft.MvvmLight.Ioc;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.RemoteDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService()
        {
            SimpleIoc.Default.Register<ICustomerService, CustomerServiceClient>();
        }
    }
}