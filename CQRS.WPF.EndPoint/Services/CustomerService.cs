using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.WPF.CustomerManagement.Application;
using CQRS.WPF.CustomerManagement.Presentation;
using CQRS.WPF.EndPoint.Contracts;
using CQRS.WPF.EndPoint.Contracts.Services;

namespace CQRS.WPF.EndPoint.Services
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