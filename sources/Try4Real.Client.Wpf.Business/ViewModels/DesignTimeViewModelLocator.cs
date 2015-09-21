using System.Collections.Generic;
using System.Linq;
using Try4Real.Client.Wpf.Business.ViewModels.Orders;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class DesignTimeViewModelLocator
    {
        public CreateNewOrderViewModelDesign CreateNewOrderViewModel
        {
            get { return new CreateNewOrderViewModelDesign(); }
        }

        public class CreateNewOrderViewModelDesign
        {
            public List<CustomerListItem> Customers { get; set; }
            public List<OrderItemViewModel> OrderItems { get; set; }
            public CustomerListItem SelectedCustomer { get; set; }
            public List<ProductItem> Products { get; set; }

            public CreateNewOrderViewModelDesign()
            {
                Customers = new List<CustomerListItem>
                {
                    new CustomerListItem {FullName = "TEST test"}
                };
                SelectedCustomer = Customers.Single();
                
                Products = new List<ProductItem>
                {
                    new ProductItem {Name = "Jacket"},
                    new ProductItem {Name = "Book"},
                };

                OrderItems = new List<OrderItemViewModel>
                {
                    new OrderItemViewModel {Product = Products.First(), Amount = 1},
                    new OrderItemViewModel {Product = Products.Last(), Amount = 5}
                };
            }
        }
    }
}