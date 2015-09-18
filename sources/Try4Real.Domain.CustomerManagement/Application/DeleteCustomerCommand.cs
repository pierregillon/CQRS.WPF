using Try4Real.Domain.CustomerManagement.Domain;

namespace Try4Real.Domain.CustomerManagement.Application
{
    public class DeleteCustomerCommand
    {
        public CustomerId Id { get; private set; }

        public DeleteCustomerCommand(CustomerId id)
        {
            Id = id;
        }
    }
}