using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Model.Order;

namespace Try4Real.Domain.Commands
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