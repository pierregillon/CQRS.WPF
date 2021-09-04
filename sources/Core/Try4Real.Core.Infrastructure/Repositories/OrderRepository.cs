using System.Linq;
using Try4Real.Domain.Order;

namespace Try4Real.Domain.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDatabase _database;

        public OrderRepository(IDatabase database) => _database = database;

        public void Add(Order.Order order)
        {
            _database.Set<Order.Order>().Add(order);
        }

        public Order.Order GetBy(OrderId orderId)
        {
            return _database.Set<Order.Order>().FirstOrDefault(x => x.Id == orderId);
        }

        public void Save(Order.Order order)
        {
            var existingOrder = GetBy(order.Id);
            _database.Set<Order.Order>().Remove(existingOrder);
            Add(order);
        }
    }
}