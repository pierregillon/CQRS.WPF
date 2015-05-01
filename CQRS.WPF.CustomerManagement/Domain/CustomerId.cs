using System;

namespace CQRS.WPF.CustomerManagement.Domain
{
    public struct CustomerId
    {
        public readonly Guid Value;

        public CustomerId(Guid value)
        {
            Value = value;
        }
    }
}