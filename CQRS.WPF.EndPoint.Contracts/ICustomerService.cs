using System.Collections.Generic;

namespace CQRS.WPF.EndPoint.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerListItem> GetCustomerListItems();
    }
}
