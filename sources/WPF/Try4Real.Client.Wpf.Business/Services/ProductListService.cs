using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.Business.Services
{
    public class ProductListService : IProductListService
    {
        private readonly IProductService _productService;

        public ProductListService(IProductService productService) => _productService = productService;


        public IEnumerable<ProductListItem> GetProducts() => _productService.GetProducts();
    }
}