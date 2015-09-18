using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Model.Order;

namespace Try4Real.Domain.Commands
{
    public class AddItemToOrderCommandHandler : ICommandHandler<AddItemToOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public AddItemToOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Handle(AddItemToOrderCommand command)
        {
            var order = _orderRepository.GetBy(command.OrderId);
            order.AddItem(command.ProductId, command.Quantity);
            _orderRepository.Save(order);
        }
    }
}