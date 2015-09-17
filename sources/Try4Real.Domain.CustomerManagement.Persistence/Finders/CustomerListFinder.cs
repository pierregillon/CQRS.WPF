using System;
using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.CustomerManagement.Domain;
using Try4Real.Domain.CustomerManagement.Presentation;

namespace Try4Real.Domain.CustomerManagement.Infrastructure.Finders
{
    public class CustomerListFinder : ICustomerListFinder
    {
        private readonly IDatabase _database;

        public CustomerListFinder(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<CustomerListItemDto> GetCustomerListItems()
        {
            var query = from customer in _database.Set<Customer>()
                        select new CustomerListItemDto
                        {
                            Id = customer.CustomerId.Value,
                            FullName = customer.FirstName + " " + customer.LastName,
                            YearOld = (int)DateTime.Now.Subtract(customer.BirthDate).TotalDays / 365,
                            Email = customer.Email
                        };

            return query.ToList();
        }

        public CustomerDetails GetDetails(Guid customerId)
        {
            var query = from customer in _database.Set<Customer>()
                        where customer.CustomerId == CustomerId.From(customerId)
                        select new CustomerDetails
                        {
                            Id = customer.CustomerId.Value,
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            BirthDate = customer.BirthDate
                        };

            return query.FirstOrDefault();
        }
    }
}