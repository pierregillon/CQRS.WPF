using System;
using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.CustomerManagement.Application;
using Try4Real.Domain.CustomerManagement.Presentation;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.EndPoint.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerListFinder _customerListFinder;
        private readonly IGate _gate;

        public CustomerService(ICustomerListFinder customerListFinder, IGate gate)
        {
            _customerListFinder = customerListFinder;
            _gate = gate;
        }

        public IEnumerable<CustomerListItem> GetCustomerListItems()
        {
            return _customerListFinder
                .GetCustomerListItems()
                .Select(x => new CustomerListItem
                {
                    FullName = x.FullName,
                    YearOld = x.YearOld,
                    Email = x.Email
                })
                .ToArray();
        }

        public void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email)
        {
            _gate.Dispatch(new CreateCustomerCommand(firstName, lastName, birthDate, email));
        }
    }
}