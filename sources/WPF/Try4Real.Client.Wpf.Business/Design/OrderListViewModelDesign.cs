using System;
using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.Design
{
    public class OrderListViewModelDesign
    {
        public List<OrderListItem> Orders { get; set; }

        public OrderListViewModelDesign() =>
            Orders = new List<OrderListItem> {
                new OrderListItem { CreationDate = DateTime.Now, CustomerFullName = "TEST test", OrderItemCount = 3, TotalAmount = 44 },
                new OrderListItem { CreationDate = DateTime.Now, CustomerFullName = "MARTIN jean", OrderItemCount = 5, TotalAmount = 12 },
            };
    }
}