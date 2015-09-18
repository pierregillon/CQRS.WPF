using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.Business.Services
{
    public class OrderListService : IOrderListService
    {
        private readonly IOrderService _orderService;

        public OrderListService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            return _orderService.GetOrderListItems();
        }
    }
}