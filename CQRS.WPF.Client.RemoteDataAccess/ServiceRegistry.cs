using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.EndPoint.Contracts.Services;
using GalaSoft.MvvmLight.Ioc;

namespace CQRS.WPF.Client.RemoteDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService()
        {
            SimpleIoc.Default.Register<ICustomerService, CustomerServiceClient>();
        }
    }
}