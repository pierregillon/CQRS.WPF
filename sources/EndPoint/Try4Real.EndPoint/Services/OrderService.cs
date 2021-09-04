using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Boostrapper;
using Try4Real.Domain.ProductCatalog;
using Try4Real.Domain.User;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;
using Try4Realse.Core.Application.Commands.AddItemToOrder;
using Try4Realse.Core.Application.Commands.CreateOrder;
using Try4Realse.Core.Application.Queries;
using OrderListItem = Try4Real.EndPoint.Contracts.OrderListItem;

namespace Try4Real.EndPoint.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IOrderListFinder _orderListFinder;

        public OrderService(ICommandDispatcher commandDispatcher, IOrderListFinder orderListFinder)
        {
            _commandDispatcher = commandDispatcher;
            _orderListFinder = orderListFinder;
        }

        public void CreateOrder(CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(CustomerId.From(request.CustomerId));
            _commandDispatcher.Dispatch(command);
            foreach (var orderItem in request.OrderItems) {
                _commandDispatcher.Dispatch(new AddItemToOrderCommand(command.OrderIdCreated, ProductId.From(orderItem.ProductId), orderItem.Quantity));
            }
        }

        public IEnumerable<OrderListItem> GetOrderListItems()
        {
            return _orderListFinder.GetOrderListItems().Select(x =>
                new OrderListItem {
                    OrderId = x.OrderId.Value,
                    CreationDate = x.CreationDate,
                    CustomerFullName = x.CustomerFullName,
                    OrderItemCount = x.OrderItemCount,
                    TotalAmount = 0
                }).ToArray();
        }
    }
}