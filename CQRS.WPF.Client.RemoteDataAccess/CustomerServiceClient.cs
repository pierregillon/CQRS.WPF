using System.Collections.Generic;
using System.ServiceModel;
using CQRS.WPF.EndPoint.Contracts;
using CQRS.WPF.EndPoint.Contracts.Services;

namespace CQRS.WPF.Client.RemoteDataAccess
{
    public class CustomerServiceClient : ClientBase<ICustomerService>, ICustomerService
    {
        public CustomerServiceClient()
            : base("CustomerServiceEndPoint") { }

        public IEnumerable<CustomerListItem> GetCustomerListItems()
        {
            return Channel.GetCustomerListItems();
        }
    }
}