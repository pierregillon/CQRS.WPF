using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.Design
{
    public class CustomerListViewModelDesign
    {
        public List<CustomerListItem> Customers { get; }

        public CustomerListViewModelDesign() =>
            Customers = new List<CustomerListItem> {
                new CustomerListItem { FullName = "TEST test", Email = "test@test.fr", YearOld = 35 },
                new CustomerListItem { FullName = "MARTIN jean", Email = "jean.martin@gmail.com", YearOld = 29 }
            };
    }
}