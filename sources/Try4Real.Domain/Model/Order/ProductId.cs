using System;

namespace Try4Real.Domain.Model.Order
{
    public struct ProductId
    {
        public readonly Guid Value;

        public ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId New()
        {
            return new ProductId(Guid.NewGuid());
        }
        public static ProductId From(Guid id)
        {
            return new ProductId(id);
        }

        public static bool operator ==(ProductId id, ProductId id2)
        {
            return id.Equals(id2);
        }
        public static bool operator !=(ProductId id, ProductId id2)
        {
            return !(id == id2);
        }
    }
}