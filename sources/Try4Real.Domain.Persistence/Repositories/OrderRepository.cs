using System.Linq;
using Try4Real.Domain.Model.Order;

namespace Try4Real.Domain.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDatabase _database;

        public OrderRepository(IDatabase database)
        {
            _database = database;
        }

        public void Add(Order order)
        {
            _database.Set<Order>().Add(order);
        }
        public Order GetBy(OrderId orderId)
        {
            return _database.Set<Order>().FirstOrDefault(x => x.Id == orderId);
        }
        public void Save(Order order)
        {
            var existingOrder = GetBy(order.Id);
            _database.Set<Order>().Remove(existingOrder);
            Add(order);
        }
    }
}