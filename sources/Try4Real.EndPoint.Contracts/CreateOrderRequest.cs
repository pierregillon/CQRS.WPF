using System;
using System.Collections.Generic;

namespace Try4Real.EndPoint.Contracts
{
    public class CreateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}