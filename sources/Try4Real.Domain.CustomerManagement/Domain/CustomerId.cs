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
        public static CustomerId From(Guid id)
        {
            return new CustomerId(id);
        }

        public static bool operator ==(CustomerId id, CustomerId id2)
        {
            return id.Equals(id2);
        }
        public static bool operator !=(CustomerId id, CustomerId id2)
        {
            return !(id == id2);
        }
    }
}