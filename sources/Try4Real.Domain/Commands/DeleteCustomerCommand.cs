using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Commands
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