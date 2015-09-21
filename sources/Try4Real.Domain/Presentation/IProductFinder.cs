using System.Collections.Generic;

namespace Try4Real.Domain.Presentation
{
    public interface IProductFinder
    {
        IEnumerable<ProductListItem> GetProducts();
    }
}