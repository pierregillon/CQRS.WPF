namespace Try4Real.Domain.ProductCatalog
{
    public class Product
    {
        public ProductId Id { get; }
        public string Name { get; }

        public Product(string name)
        {
            Id = ProductId.New();
            Name = name;
        }
    }
}