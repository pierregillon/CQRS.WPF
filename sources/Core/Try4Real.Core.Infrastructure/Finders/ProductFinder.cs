using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.ProductCatalog;
using Try4Realse.Core.Application.Queries;

namespace Try4Real.Domain.Infrastructure.Finders
{
    public class ProductFinder : IProductFinder
    {
        private readonly IDatabase _database;

        public ProductFinder(IDatabase database) => _database = database;

        public IEnumerable<ProductListItem> GetProducts()
        {
            var query = from product in _database.Set<Product>()
                select new ProductListItem {
                    Id = product.Id,
                    Name = product.Name
                };
            return query.ToArray();
        }
    }
}