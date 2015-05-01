using CQRS.WPF.CustomerManagement.Domain;

namespace CQRS.WPF.CustomerManagement.Infrastructure
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(CustomerId customerId);
    }
}
