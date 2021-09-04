using System;

namespace Try4Real.Domain.ProductCatalog
{
    public struct ProductId
    {
        public readonly Guid Value;

        public ProductId(Guid value) => Value = value;

        public static ProductId New() => new ProductId(Guid.NewGuid());

        public static ProductId From(Guid id) => new ProductId(id);

        public static bool operator ==(ProductId id, ProductId id2) => id.Equals(id2);
        public static bool operator !=(ProductId id, ProductId id2) => !(id == id2);
    }
}