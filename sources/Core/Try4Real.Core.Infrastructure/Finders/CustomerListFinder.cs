using System;
using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.User;
using Try4Realse.Core.Application.Queries;

namespace Try4Real.Domain.Infrastructure.Finders
{
    public class CustomerListFinder : ICustomerListFinder
    {
        private readonly IDatabase _database;

        public CustomerListFinder(IDatabase database) => _database = database;

        public IEnumerable<CustomerListItemDto> GetCustomerListItems()
        {
            var query = from customer in _database.Set<Customer>()
                select new CustomerListItemDto {
                    Id = customer.CustomerId.Value,
                    FullName = customer.FirstName + " " + customer.LastName,
                    YearOld = (int) DateTime.Now.Subtract(customer.BirthDate).TotalDays / 365,
                    Email = customer.Email
                };

            return query.ToList();
        }

        public CustomerDetails GetDetails(CustomerId customerId)
        {
            var query = from customer in _database.Set<Customer>()
                where customer.CustomerId == customerId
                select new CustomerDetails {
                    Id = customer.CustomerId.Value,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    BirthDate = customer.BirthDate,
                    Email = customer.Email,
                };

            return query.FirstOrDefault();
        }
    }
}