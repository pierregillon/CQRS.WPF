using System.Collections.Generic;

namespace Try4Real.Domain.Presentation
{
    public interface IOrderListFinder
    {
        IEnumerable<OrderListItem> GetOrderListItems();
    }
}