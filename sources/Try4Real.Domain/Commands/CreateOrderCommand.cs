using Try4Real.Domain.Model.Order;
using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Commands
{
    public class CreateOrderCommand
    {
        public CustomerId CustomerId { get; private set; }
        public OrderId OrderIdCreated { get; set; }

        public CreateOrderCommand(CustomerId customerId)
        {
            CustomerId = customerId;
        }
    }
}
