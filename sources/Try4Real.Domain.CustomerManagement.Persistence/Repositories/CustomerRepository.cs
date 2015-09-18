using System;
using System.Linq;
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
            var existing = _database.Set<Customer>().First(x => x.CustomerId == customer.CustomerId);
            _database.Set<Customer>().Remove(existing);
            _database.Set<Customer>().Add(customer);
        }
        public void Delete(CustomerId customerId)
        {
            throw new NotImplementedException();
        }
        public Customer GetBy(CustomerId id)
        {
            return _database.Set<Customer>().FirstOrDefault(x => x.CustomerId == id);
        }
    }
}