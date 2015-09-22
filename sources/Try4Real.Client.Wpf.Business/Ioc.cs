using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using Try4Real.Client.Wpf.Business.Dialog;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.Client.Wpf.Business.ViewModels.Main;
using Try4Real.Client.Wpf.Business.ViewModels.Orders;
using Try4Real.Client.Wpf.Business.ViewModels.Users;

namespace Try4Real.Client.Wpf.Business
{
    public class Ioc
    {
        private static readonly Ioc _instance = new Ioc();
        public static Ioc Instance
        {
            get { return _instance; }
        }

        private readonly Container _container;

        public Ioc()
        {
            _container = new Container();
        }

        public void Init(IServiceRegistry serviceRegistry, IDialogService dialogService)
        {
            serviceRegistry.RegisterService(_container);

            _container.RegisterSingleton<ICustomerListService, CustomerListService>();
            _container.RegisterSingleton<IOrderListService, OrderListService>();
            _container.RegisterSingleton<ICustomerDetailService, CustomerDetailService>();
            _container.RegisterSingleton<IOrderDetailService, OrderDetailService>();
            _container.RegisterSingleton<IProductListService, ProductListService>();

            _container.RegisterSingleton<MainViewModel>();
            _container.RegisterSingleton<CreateNewOrderViewModel>();

            _container.Register<CustomerListViewModel>();
            _container.Register<OrderListViewModel>();
            _container.Register<CustomerDetailViewModel>();

            _container.RegisterSingleton(() => Messenger.Default);

            _container.RegisterSingleton(typeof(IViewModelFactory<>), typeof(ViewModelFactory<>));
            _container.RegisterSingleton(dialogService);
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}