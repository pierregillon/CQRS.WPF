using System.Collections.Generic;
using CQRS.WPF.CustomerManagement.Presentation;

namespace CQRS.WPF.CustomerManagement.Persistence.Finders
{
    public class CustomerListFinder : ICustomerListFinder
    {
        public IEnumerable<CustomerListItemDto> GetCustomerListItems()
        {
            return new List<CustomerListItemDto>
            {
                new CustomerListItemDto {FirstName = "Test", LastName = "test"}
            };
        }
    }
}