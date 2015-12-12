using System;
using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Boostrapper;
using Try4Real.Domain.Commands;
using Try4Real.Domain.Model.User;
using Try4Real.Domain.Presentation;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;
using CustomerDetails = Try4Real.EndPoint.Contracts.CustomerDetails;

namespace Try4Real.EndPoint.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerListFinder _customerFinder;
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomerService(ICustomerListFinder customerFinder, ICommandDispatcher commandDispatcher)
        {
            _customerFinder = customerFinder;
            _commandDispatcher = commandDispatcher;
        }

        public IEnumerable<CustomerListItem> GetCustomerListItems()
        {
            return _customerFinder
                .GetCustomerListItems()
                .Select(x => new CustomerListItem
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    YearOld = x.YearOld,
                    Email = x.Email
                })
                .ToArray();
        }
        public CustomerDetails GetCustomerDetails(Guid customerId)
        {
            var details = _customerFinder.GetDetails(CustomerId.From(customerId));
            return new CustomerDetails
            {
                Id = details.Id,
                FirstName = details.FirstName,
                LastName = details.LastName,
                BirthDate = details.BirthDate,
                Email = details.Email,
            };
        }
        public void UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            _commandDispatcher.Dispatch(new UpdateCustomerCommand(CustomerId.From(customerDetails.Id), customerDetails.FirstName, customerDetails.LastName, customerDetails.BirthDate, customerDetails.Email));
        }
        public void DeleteCustomer(Guid id)
        {
            _commandDispatcher.Dispatch(new DeleteCustomerCommand(CustomerId.From(id)));
        }
        public void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email)
        {
            _commandDispatcher.Dispatch(new CreateCustomerCommand(firstName, lastName, birthDate, email));
        }
    }
}