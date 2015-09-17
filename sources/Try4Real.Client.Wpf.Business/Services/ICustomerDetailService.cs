using System;
using Try4Real.EndPoint.Contracts;
using Try4Real.EndPoint.Contracts.Services;

namespace Try4Real.Client.Wpf.Business.Services
{
    public interface ICustomerDetailService
    {
        CustomerDetails GetCustomerDetails(Guid customerId);
    }

    public class CustomerDetailService: ICustomerDetailService
    {
        private readonly ICustomerService _customerService;

        public CustomerDetailService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public CustomerDetails GetCustomerDetails(Guid customerId)
        {
            return _customerService.GetCustomerDetails(customerId);
        }
    }
}