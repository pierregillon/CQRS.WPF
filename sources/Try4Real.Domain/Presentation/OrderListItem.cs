using System;
using Try4Real.Domain.Model.Order;

namespace Try4Real.Domain.Presentation
{
    public class OrderListItem
    {
        public OrderId OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerFullName { get; set; }
        public int OrderItemCount { get; set; }
    }
}