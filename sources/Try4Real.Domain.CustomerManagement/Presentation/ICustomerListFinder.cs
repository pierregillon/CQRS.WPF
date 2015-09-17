using System;
using System.Collections.Generic;

namespace Try4Real.Domain.CustomerManagement.Presentation
{
    public interface ICustomerListFinder
    {
        IEnumerable<CustomerListItemDto> GetCustomerListItems();
        CustomerDetails GetDetails(Guid customerId);
    }
}