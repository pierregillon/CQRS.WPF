using Try4Real.Domain.Commands;

namespace Try4Real.Domain.Model.Order
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetBy(OrderId orderId);
        void Save(Order order);
    }
}