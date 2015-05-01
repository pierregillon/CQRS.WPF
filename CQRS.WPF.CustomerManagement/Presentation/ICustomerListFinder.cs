using System.Collections.Generic;

namespace CQRS.WPF.CustomerManagement.Presentation
{
    public interface ICustomerListFinder
    {
        IEnumerable<CustomerListItemDto> GetCustomerListItems();
    }
}