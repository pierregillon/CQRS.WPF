namespace Try4Real.Domain.Model.User
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(CustomerId customerId);
        Customer GetBy(CustomerId id);
    }
}
