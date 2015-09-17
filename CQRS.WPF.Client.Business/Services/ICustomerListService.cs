using System;
using System.Collections.Generic;
using CQRS.WPF.EndPoint.Contracts;

namespace CQRS.WPF.Client.Business.Services
{
    public interface ICustomerListService
    {
        IEnumerable<CustomerListItem> GetCustomers();
        void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email);
    }
}