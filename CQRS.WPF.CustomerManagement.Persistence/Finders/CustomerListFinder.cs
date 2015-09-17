using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.WPF.CustomerManagement.Domain;
using CQRS.WPF.CustomerManagement.Persistence.Repositories;
using CQRS.WPF.CustomerManagement.Presentation;

namespace CQRS.WPF.CustomerManagement.Persistence.Finders
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
                            FullName = customer.FirstName + " " + customer.LastName,
                            YearOld = (int)DateTime.Now.Subtract(customer.BirthDate).TotalDays / 365,
                            Email = customer.Email
                        };

            return query.ToList();
        }
    }
}