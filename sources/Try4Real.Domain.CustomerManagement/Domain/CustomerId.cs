using System;

namespace Try4Real.Domain.CustomerManagement.Domain
{
    public struct CustomerId
    {
        public readonly Guid Value;

        public CustomerId(Guid value)
        {
            Value = value;
        }

        public static CustomerId New()
        {
            return new CustomerId(Guid.NewGuid());
        }
    }
}