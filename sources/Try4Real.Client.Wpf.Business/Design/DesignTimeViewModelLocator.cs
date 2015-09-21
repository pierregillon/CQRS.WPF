namespace Try4Real.Client.Wpf.Business.Design
{
    public class DesignTimeViewModelLocator
    {
        public CreateNewOrderViewModelDesign CreateNewOrderViewModel
        {
            get { return new CreateNewOrderViewModelDesign(); }
        }

        public CustomerListViewModelDesign CustomerListViewModel
        {
            get { return new CustomerListViewModelDesign(); }
        }

        public OrderListViewModelDesign OrderListViewModel
        {
            get { return new OrderListViewModelDesign(); }
        }
    }
}