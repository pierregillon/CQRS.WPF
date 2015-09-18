using System.Collections.Generic;
using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Presentation
{
    public interface ICustomerListFinder
    {
        IEnumerable<CustomerListItemDto> GetCustomerListItems();
        CustomerDetails GetDetails(CustomerId customerId);
    }
}