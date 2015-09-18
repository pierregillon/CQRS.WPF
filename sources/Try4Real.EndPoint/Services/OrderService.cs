using Try4Real.Domain.Commands;
using Try4Real.Domain.Model.Order;
using Try4Real.Domain.Model.User;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.EndPoint.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGate _gate;

        public OrderService(IGate gate)
        {
            _gate = gate;
        }

        public void CreateOrder(CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(CustomerId.From(request.CustomerId));
            _gate.Dispatch(command);
            foreach (var orderItem in request.OrderItems) {
                _gate.Dispatch(new AddItemToOrderCommand(command.OrderIdCreated, ProductId.From(orderItem.ProductId), orderItem.Quantity));
            }
        }
    }
}
