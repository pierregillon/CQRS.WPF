using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Model.ProductCatalog;
using Try4Real.Domain.Presentation;

namespace Try4Real.Domain.Infrastructure.Finders
{
    public class ProductFinder : IProductFinder
    {
        private readonly IDatabase _database;

        public ProductFinder(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            var query = from product in _database.Set<Product>()
                        select new ProductListItem
                        {
                            Id = product.Id,
                            Name = product.Name
                        };
            return query.ToArray();
        }
    }
}
