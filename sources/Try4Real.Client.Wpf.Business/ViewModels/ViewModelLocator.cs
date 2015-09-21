using Try4Real.Client.Wpf.Business.ViewModels.Main;
using Try4Real.Client.Wpf.Business.ViewModels.Orders;
using Try4Real.Client.Wpf.Business.ViewModels.Users;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class ViewModelLocator
    {
        public CustomerListViewModel CustomerListViewModel
        {
            get { return Ioc.Instance.GetInstance<CustomerListViewModel>(); }
        }
        public MainViewModel MainViewModel
        {
            get { return Ioc.Instance.GetInstance<MainViewModel>(); }
        }
        public CustomerDetailViewModel CustomerDetailViewModel
        {
            get { return Ioc.Instance.GetInstance<CustomerDetailViewModel>(); }
        }
        public OrderListViewModel OrderListViewModel
        {
            get { return Ioc.Instance.GetInstance<OrderListViewModel>(); }
        }
        public CreateNewOrderViewModel CreateNewOrderViewModel
        {
            get { return Ioc.Instance.GetInstance<CreateNewOrderViewModel>(); }
        }
    }
}
