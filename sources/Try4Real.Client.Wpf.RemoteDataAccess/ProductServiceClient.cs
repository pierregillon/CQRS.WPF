using System.Collections.Generic;
using System.ServiceModel;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.RemoteDataAccess
{
    public class ProductServiceClient : ClientBase<IProductService>, IProductService
    {
        public ProductServiceClient()
            : base("ProductServiceEndPoint")
        {
            
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            return Channel.GetProducts();
        }
    }
}