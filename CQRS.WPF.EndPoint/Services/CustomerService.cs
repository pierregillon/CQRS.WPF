using System.Collections.Generic;
using System.Linq;
using CQRS.WPF.CustomerManagement.Presentation;
using CQRS.WPF.EndPoint.Contracts;

namespace CQRS.WPF.EndPoint.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerListFinder _customerListFinder;

        public CustomerService(ICustomerListFinder customerListFinder)
        {
            _customerListFinder = customerListFinder;
        }

        public IEnumerable<CustomerListItem> GetCustomerListItems()
        {
            return _customerListFinder
                .GetCustomerListItems()
                .Select(x => new CustomerListItem
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });
        }
    }
}