using System;
using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.Business.Services
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