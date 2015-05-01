using System;
using CQRS.WPF.CustomerManagement.Domain;
using CQRS.WPF.CustomerManagement.Infrastructure;

namespace CQRS.WPF.CustomerManagement.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
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
