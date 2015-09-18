using System.Collections.Generic;
using Try4Real.Domain.CustomerManagement.Domain;

namespace Try4Real.Domain.CustomerManagement.Presentation
{
    public interface ICustomerListFinder
    {
        IEnumerable<CustomerListItemDto> GetCustomerListItems();
        CustomerDetails GetDetails(CustomerId customerId);
    }
}