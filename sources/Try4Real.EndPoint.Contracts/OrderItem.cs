using System;

namespace Try4Real.EndPoint.Contracts
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}