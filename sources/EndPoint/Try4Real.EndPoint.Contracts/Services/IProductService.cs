using System.Collections.Generic;
using System.ServiceModel;

namespace Try4Real.EndPoint.Contracts.Services
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<ProductListItem> GetProducts();
    }
}