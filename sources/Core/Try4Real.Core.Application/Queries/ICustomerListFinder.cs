using System.Collections.Generic;
using Try4Real.Domain.User;

namespace Try4Realse.Core.Application.Queries
{
    public interface ICustomerListFinder
    {
        IEnumerable<CustomerListItemDto> GetCustomerListItems();
        CustomerDetails GetDetails(CustomerId customerId);
    }
}