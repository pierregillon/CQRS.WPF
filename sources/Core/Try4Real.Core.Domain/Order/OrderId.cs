using System;

namespace Try4Real.Domain.Order
{
    public struct OrderId
    {
        public readonly Guid Value;

        public OrderId(Guid value) => Value = value;

        public static OrderId New() => new OrderId(Guid.NewGuid());

        public static OrderId From(Guid id) => new OrderId(id);

        public static bool operator ==(OrderId id, OrderId id2) => id.Equals(id2);
        public static bool operator !=(OrderId id, OrderId id2) => !(id == id2);
    }
}