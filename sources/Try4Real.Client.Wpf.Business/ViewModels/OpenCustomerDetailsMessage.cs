using System;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    internal class OpenCustomerDetailsMessage
    {
        public Guid CustomerId { get; private set; }

        public OpenCustomerDetailsMessage(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}