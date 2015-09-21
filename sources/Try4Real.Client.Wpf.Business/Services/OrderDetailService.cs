using System;
using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderService _orderService;

        public OrderDetailService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void CreateOrder(Guid customerId, IEnumerable<OrderItem> orderItems)
        {
            _orderService.CreateOrder(new CreateOrderRequest
            {
                CustomerId = customerId,
                OrderItems = orderItems
            });
        }
    }
}