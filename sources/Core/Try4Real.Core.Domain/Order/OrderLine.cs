using Try4Real.Domain.ProductCatalog;

namespace Try4Real.Domain.Order
{
    public class OrderLine
    {
        public ProductId ProductId { get; private set; }
        public int Quantity { get; private set; }

        public OrderLine(int quantity, ProductId productId)
        {
            Quantity = quantity;
            ProductId = productId;
        }
        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}