using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.Services
{
    public interface IProductListService
    {
        IEnumerable<ProductListItem> GetProducts();
    }
}