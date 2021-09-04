using Try4Real.Domain.Order;
using Try4Real.Domain.ProductCatalog;

namespace Try4Realse.Core.Application.Commands.AddItemToOrder
{
    public class AddItemToOrderCommand
    {
        public OrderId OrderId { get; set; }
        public ProductId ProductId { get; private set; }
        public int Quantity { get; private set; }

        public AddItemToOrderCommand(OrderId orderId, ProductId productId, int quantity)
        {
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}