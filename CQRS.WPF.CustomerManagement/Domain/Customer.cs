using System;

namespace CQRS.WPF.CustomerManagement.Domain
{
    public class Customer
    {
        public CustomerId CustomerId { get; private set; }

        public Customer()
        {
            CustomerId = new CustomerId(Guid.NewGuid());
        }
    }
}