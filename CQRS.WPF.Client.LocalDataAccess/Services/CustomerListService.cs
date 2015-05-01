using System.Collections.Generic;
using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.EndPoint.Contracts;

namespace CQRS.WPF.Client.LocalDataAccess.Services
{
    public class CustomerListService : ICustomerListService
    {
        private readonly ICustomerService _customerService;

        public CustomerListService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            return _customerService.GetCustomerListItems();
        }
    }
}