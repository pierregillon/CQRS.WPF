using System;
using System.Collections.Generic;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.Services
{
    public interface ICustomerListService
    {
        IEnumerable<CustomerListItem> GetCustomers();
        void CreateCustomer(string firstName, string lastName, DateTime birthDate, string email);
    }
}