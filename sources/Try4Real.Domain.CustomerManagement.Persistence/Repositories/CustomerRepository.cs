using System;
using Try4Real.Domain.CustomerManagement.Domain;

namespace Try4Real.Domain.CustomerManagement.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabase _database;

        public CustomerRepository(IDatabase database)
        {
            _database = database;
        }

        public void Add(Customer customer)
        {
            _database.Set<Customer>().Add(customer);
        }
        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
        public void Delete(CustomerId customerId)
        {
            throw new NotImplementedException();
        }
    }
}