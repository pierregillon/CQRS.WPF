using System.Collections.Generic;

namespace Try4Realse.Core.Application.Queries
{
    public interface IOrderListFinder
    {
        IEnumerable<OrderListItem> GetOrderListItems();
    }
}