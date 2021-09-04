using Try4Real.Domain.Order;
using Try4Real.Domain.User;

namespace Try4Realse.Core.Application.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CustomerId CustomerId { get; }
        public OrderId OrderIdCreated { get; set; }

        public CreateOrderCommand(CustomerId customerId) => CustomerId = customerId;
    }
}