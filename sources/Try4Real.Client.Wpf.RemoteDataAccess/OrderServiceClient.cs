using System.Collections.Generic;
using System.ServiceModel;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.RemoteDataAccess
{
    public class OrderServiceClient : ClientBase<IOrderService>, IOrderService
    {
        public OrderServiceClient()
            : base("OrderServiceEndPoint")
        {
            
        }

        public void CreateOrder(CreateOrderRequest request)
        {
            Channel.CreateOrder(request);
        }
        public IEnumerable<OrderListItem> GetOrderListItems()
        {
            return Channel.GetOrderListItems();
        }
    }
}