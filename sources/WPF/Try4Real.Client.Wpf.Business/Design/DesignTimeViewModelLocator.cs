namespace Try4Real.Client.Wpf.Business.Design
{
    public class DesignTimeViewModelLocator
    {
        public CreateNewOrderViewModelDesign CreateNewOrderViewModel => new CreateNewOrderViewModelDesign();

        public CustomerListViewModelDesign CustomerListViewModel => new CustomerListViewModelDesign();

        public OrderListViewModelDesign OrderListViewModel => new OrderListViewModelDesign();
    }
}