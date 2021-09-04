using System.Linq;
using Try4Real.Domain.User;

namespace Try4Real.Domain.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabase _database;

        public CustomerRepository(IDatabase database) => _database = database;

        public void Add(Customer customer)
        {
            _database.Set<Customer>().Add(customer);
        }

        public void Update(Customer customer)
        {
            Delete(customer.CustomerId);
            Add(customer);
        }

        public void Delete(CustomerId customerId)
        {
            var existing = _database.Set<Customer>().First(x => x.CustomerId == customerId);
            _database.Set<Customer>().Remove(existing);
        }

        public Customer GetBy(CustomerId id)
        {
            return _database.Set<Customer>().FirstOrDefault(x => x.CustomerId == id);
        }
    }
}