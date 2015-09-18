using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Commands;
using Try4Real.Domain.Model.Order;
using Try4Real.Domain.Model.User;
using Try4Real.Domain.Presentation;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;
using OrderListItem = Try4Real.EndPoint.Contracts.OrderListItem;

namespace Try4Real.EndPoint.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGate _gate;
        private readonly IOrderListFinder _orderListFinder;

        public OrderService(IGate gate, IOrderListFinder orderListFinder)
        {
            _gate = gate;
            _orderListFinder = orderListFinder;
        }

        public void CreateOrder(CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(CustomerId.From(request.CustomerId));
            _gate.Dispatch(command);
            foreach (var orderItem in request.OrderItems) {
                _gate.Dispatch(new AddItemToOrderCommand(command.OrderIdCreated, ProductId.From(orderItem.ProductId), orderItem.Quantity));
            }
        }

        public IEnumerable<OrderListItem> GetOrderListItems()
        {
            return _orderListFinder.GetOrderListItems().Select(x =>
                new OrderListItem
                {
                    OrderId = x.OrderId.Value,
                    CreationDate = x.CreationDate,
                    CustomerFullName = x.CustomerFullName,
                    TotalAmount = 0
                }).ToArray();
        }
    }
}