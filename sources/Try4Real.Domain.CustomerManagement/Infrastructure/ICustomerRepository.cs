using Try4Real.Domain.CustomerManagement.Domain;

namespace Try4Real.Domain.CustomerManagement.Infrastructure
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(CustomerId customerId);
        Customer GetBy(CustomerId id);
    }
}
