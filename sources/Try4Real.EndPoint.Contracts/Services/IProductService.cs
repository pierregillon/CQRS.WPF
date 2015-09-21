using System.Collections.Generic;

namespace Try4Real.EndPoint.Contracts.Services
{
    public interface IProductService
    {
        IEnumerable<ProductListItem> GetProducts();
    }
}