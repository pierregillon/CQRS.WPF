using System;

namespace Try4Real.EndPoint.Contracts
{
    public class OrderListItem
    {
        public Guid OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerFullName { get; set; }
        public int TotalAmount { get; set; }
    }
}