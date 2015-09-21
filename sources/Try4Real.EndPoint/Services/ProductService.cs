using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Presentation;
using Try4Real.EndPoint.Contracts.Services;
using ProductListItem = Try4Real.EndPoint.Contracts.ProductListItem;

namespace Try4Real.EndPoint.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductFinder _productFinder;

        public ProductService(IProductFinder productFinder)
        {
            _productFinder = productFinder;
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            return _productFinder.GetProducts().Select(x => new ProductListItem
            {
                Id = x.Id.Value,
                Name = x.Name
            }).ToArray();
        }
    }
}
