using Try4Real.Domain.Order;
using Try4Realse.Core.Application.Commands._Base;

namespace Try4Realse.Core.Application.Commands.AddItemToOrder
{
    public class AddItemToOrderCommandHandler : ICommandHandler<AddItemToOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public AddItemToOrderCommandHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public void Handle(AddItemToOrderCommand command)
        {
            var order = _orderRepository.GetBy(command.OrderId);
            order.AddItem(command.ProductId, command.Quantity);
            _orderRepository.Save(order);
        }
    }
}