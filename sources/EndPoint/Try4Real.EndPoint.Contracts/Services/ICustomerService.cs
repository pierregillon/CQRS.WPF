using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Try4Real.EndPoint.Contracts.Services
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IEnumerable<CustomerListItem> GetCustomerListItems();

        [OperationContract]
        void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email);

        [OperationContract]
        CustomerDetails GetCustomerDetails(Guid customerId);

        [OperationContract]
        void UpdateCustomerDetails(CustomerDetails customerDetails);

        [OperationContract]
        void DeleteCustomer(Guid id);
    }
}