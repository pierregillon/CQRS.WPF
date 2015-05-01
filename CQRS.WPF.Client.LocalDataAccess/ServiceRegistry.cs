using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.EndPoint.Contracts.Services;
using GalaSoft.MvvmLight.Ioc;

namespace CQRS.WPF.Client.LocalDataAccess
{
    public class ServiceRegistry : IServiceRegistry
    {
        public void RegisterService()
        {
            EndPoint.Ioc.Instance.Init();
            SimpleIoc.Default.Register(EndPoint.Ioc.Instance.GetInstance<ICustomerService>);
        }
    }
}