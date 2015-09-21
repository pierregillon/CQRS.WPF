using System;
using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.Services
{
    public interface IOrderDetailService
    {
        void CreateOrder(Guid customerId, IEnumerable<OrderItem> orderItems);
    }
}