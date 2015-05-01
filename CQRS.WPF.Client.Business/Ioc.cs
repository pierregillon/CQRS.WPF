using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.Client.Business.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace CQRS.WPF.Client.Business
{
    public class Ioc
    {
        private static readonly Ioc _instance = new Ioc();
        public static Ioc Instance
        {
            get { return _instance; }
        }

        public void Init(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterService();

            SimpleIoc.Default.Register<CustomerListViewModel>();
        }
    }
}