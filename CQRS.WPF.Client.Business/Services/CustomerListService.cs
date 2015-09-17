using System;
using System.Collections.Generic;
using CQRS.WPF.EndPoint.Contracts;
using CQRS.WPF.EndPoint.Contracts.Services;

namespace CQRS.WPF.Client.Business.Services
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

        public void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email)
        {
            _customerService.CreateCustomer(firstName, lastName, birthDate, email);
        }
    }
}