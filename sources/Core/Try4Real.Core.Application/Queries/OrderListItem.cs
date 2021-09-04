using System;
using Try4Real.Domain.Order;

namespace Try4Realse.Core.Application.Queries
{
    public class OrderListItem
    {
        public OrderId OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerFullName { get; set; }
        public int OrderItemCount { get; set; }
    }
}