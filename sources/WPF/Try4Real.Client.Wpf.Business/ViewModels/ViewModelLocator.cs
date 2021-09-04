using Try4Real.Client.Wpf.Business.ViewModels.Main;
using Try4Real.Client.Wpf.Business.ViewModels.Orders;
using Try4Real.Client.Wpf.Business.ViewModels.Users;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class ViewModelLocator
    {
        public CustomerListViewModel CustomerListViewModel => Ioc.Instance.GetInstance<CustomerListViewModel>();
        public MainViewModel MainViewModel => Ioc.Instance.GetInstance<MainViewModel>();
        public CustomerDetailViewModel CustomerDetailViewModel => Ioc.Instance.GetInstance<CustomerDetailViewModel>();
        public OrderListViewModel OrderListViewModel => Ioc.Instance.GetInstance<OrderListViewModel>();
        public CreateNewOrderViewModel CreateNewOrderViewModel => Ioc.Instance.GetInstance<CreateNewOrderViewModel>();
    }
}