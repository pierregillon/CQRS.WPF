using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
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

        public void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email)
        {
            Channel.CreateCustomer(firstName, lastName, birthDate, email);
        }
    }
}