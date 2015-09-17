using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Business
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

            SimpleIoc.Default.Register<ICustomerListService, CustomerListService>();
            SimpleIoc.Default.Register<ICustomerDetailService, CustomerDetailService>();

            SimpleIoc.Default.Register<CustomerListViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CustomerDetailViewModel>();

            SimpleIoc.Default.Register(()=>Messenger.Default);
        }
    }
}