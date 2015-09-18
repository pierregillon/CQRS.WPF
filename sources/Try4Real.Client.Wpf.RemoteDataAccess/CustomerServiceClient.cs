using System;
using System.Collections.Generic;
using System.ServiceModel;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.RemoteDataAccess
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
        public CustomerDetails GetCustomerDetails(Guid customerId)
        {
            return Channel.GetCustomerDetails(customerId);
        }
        public void UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            Channel.UpdateCustomerDetails(customerDetails);
        }
        public void DeleteCustomer(Guid id)
        {
            Channel.DeleteCustomer(id);
        }
    }
}