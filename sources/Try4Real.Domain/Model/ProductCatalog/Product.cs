namespace Try4Real.Domain.Model.ProductCatalog
{
    public class Product
    {
        public ProductId Id { get; private set; }
        public string Name { get; private set; }

        public Product(string name)
        {
            Id = ProductId.New();
            Name = name;
        }
    }
}
