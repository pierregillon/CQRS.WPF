namespace Try4Real.Domain.Order
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetBy(OrderId orderId);
        void Save(Order order);
    }
}