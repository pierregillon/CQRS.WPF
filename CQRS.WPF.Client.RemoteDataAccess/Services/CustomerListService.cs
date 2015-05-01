using System.Collections.Generic;
using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.EndPoint.Contracts;
using CQRS.WPF.EndPoint.Contracts.Services;

namespace CQRS.WPF.Client.RemoteDataAccess.Services
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