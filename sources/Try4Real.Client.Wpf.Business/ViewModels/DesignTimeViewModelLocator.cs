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

        public CustomerListViewModelDesign CustomerListViewModel
        {
            get { return new CustomerListViewModelDesign(); }
        }

        public class CreateNewOrderViewModelDesign
        {
            public List<CustomerListItem> Customers { get; set; }
            public List<OrderItemViewModel> OrderItems { get; set; }
            public CustomerListItem SelectedCustomer { get; set; }
            public List<ProductListItem> Products { get; set; }

            public CreateNewOrderViewModelDesign()
            {
                Customers = new List<CustomerListItem>
                {
                    new CustomerListItem {FullName = "TEST test"}
                };
                SelectedCustomer = Customers.Single();

                Products = new List<ProductListItem>
                {
                    new ProductListItem {Name = "Jacket"},
                    new ProductListItem {Name = "Book"},
                };

                OrderItems = new List<OrderItemViewModel>
                {
                    new OrderItemViewModel {Product = Products.First(), Amount = 1},
                    new OrderItemViewModel {Product = Products.Last(), Amount = 5}
                };
            }
        }
    }

    public class CustomerListViewModelDesign
    {
        public List<CustomerListItem> Customers { get; private set; }

        public CustomerListViewModelDesign()
        {
            Customers = new List<CustomerListItem>
            {
                new CustomerListItem{FullName = "TEST test", Email = "test@test.fr", YearOld = 35},
                new CustomerListItem{FullName = "MARTIN jean", Email = "jean.martin@gmail.com", YearOld = 29}
            };
        }
    }
}