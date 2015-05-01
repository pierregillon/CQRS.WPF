using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.Client.LocalDataAccess.Services;
using CQRS.WPF.EndPoint.Contracts;
using GalaSoft.MvvmLight.Ioc;

namespace CQRS.WPF.Client.LocalDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService()
        {
            SimpleIoc.Default.Register<ICustomerListService, CustomerListService>();
            SimpleIoc.Default.Register(EndPoint.Ioc.Instance.GetInstance<ICustomerService>);

            EndPoint.Ioc.Instance.Init();
        }
    }
}