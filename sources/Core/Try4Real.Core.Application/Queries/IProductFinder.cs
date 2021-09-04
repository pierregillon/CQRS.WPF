using System.Collections.Generic;

namespace Try4Realse.Core.Application.Queries
{
    public interface IProductFinder
    {
        IEnumerable<ProductListItem> GetProducts();
    }
}