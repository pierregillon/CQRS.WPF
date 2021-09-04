using Try4Real.Domain.Order;
using Try4Realse.Core.Application.Commands.Base;

namespace Try4Realse.Core.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Handle(CreateOrderCommand command)
        {
            var order = new Order(command.CustomerId);
            order.Open();
            _orderRepository.Add(order);
            
            // Affect the id created to the initial command
            // to notify caller the information.
            command.OrderIdCreated = order.Id;
        }
    }
}