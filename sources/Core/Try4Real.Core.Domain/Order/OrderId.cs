using System;

namespace Try4Real.Domain.Order
{
    public struct OrderId
    {
        public readonly Guid Value;

        public OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId New()
        {
            return new OrderId(Guid.NewGuid());
        }
        public static OrderId From(Guid id)
        {
            return new OrderId(id);
        }

        public static bool operator ==(OrderId id, OrderId id2)
        {
            return id.Equals(id2);
        }
        public static bool operator !=(OrderId id, OrderId id2)
        {
            return !(id == id2);
        }
    }
}