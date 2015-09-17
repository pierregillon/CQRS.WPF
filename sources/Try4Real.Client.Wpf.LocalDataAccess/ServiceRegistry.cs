using GalaSoft.MvvmLight.Ioc;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.LocalDataAccess
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