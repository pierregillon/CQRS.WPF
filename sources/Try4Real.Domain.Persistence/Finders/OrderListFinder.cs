using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Model.Order;
using Try4Real.Domain.Model.User;
using Try4Real.Domain.Presentation;

namespace Try4Real.Domain.Infrastructure.Finders
{
    public class OrderListFinder : IOrderListFinder
    {
        private readonly IDatabase _database;

        public OrderListFinder(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<OrderListItem> GetOrderListItems()
        {
            var query = from customer in _database.Set<Customer>()
                        join order in _database.Set<Order>() on customer.CustomerId equals order.CustomerId 
                        select new OrderListItem
                        {
                            OrderId = order.Id,
                            CreationDate = order.CreationDate,
                            CustomerFullName = customer.FirstName + " "+ customer.LastName,
                            OrderItemCount = order.ItemCount
                        };

            return query.ToArray();
        }
    }
}