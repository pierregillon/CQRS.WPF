using System;

namespace Try4Real.Domain.User
{
    public struct CustomerId
    {
        public readonly Guid Value;

        public CustomerId(Guid value) => Value = value;

        public static CustomerId New() => new CustomerId(Guid.NewGuid());
        public static CustomerId From(Guid id) => new CustomerId(id);

        public static bool operator ==(CustomerId id, CustomerId id2) => id.Equals(id2);
        public static bool operator !=(CustomerId id, CustomerId id2) => !(id == id2);
    }
}