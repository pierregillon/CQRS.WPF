using System;
using System.Collections.Generic;
using System.Linq;
using Try4Real.Domain.Model.ProductCatalog;
using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Model.Order
{
    public class Order
    {
        private readonly IList<OrderLine> _lines = new List<OrderLine>() ;

        public OrderId Id { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime? PendingStartDate { get; private set; }
        public DateTime? PendingEndDate { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int ItemCount { get { return _lines.Count; } }

        public Order(CustomerId customerId)
        {
            Id = OrderId.New();
            CreationDate = DateTime.Now;
            CustomerId = customerId;
        }

        public void Open()
        {
            Status = OrderStatus.Open;
        }
        public void Place()
        {
            if (Status != OrderStatus.Open) {
                throw new InvalidOrderStatus("Cannot place order that is not currently open.");
            }
            Status = OrderStatus.Pending;
            PendingStartDate = DateTime.Now;
        }
        public void Cancel()
        {
            if (Status != OrderStatus.Pending) {
                throw new InvalidOrderStatus("Cannot cancel order that is not currently pending.");
            }
            Status = OrderStatus.Cancelled;
            PendingEndDate = DateTime.Now;
        }
        public void Validate()
        {
            if (Status != OrderStatus.Pending) {
                throw new InvalidOrderStatus("Cannot validate order that is not currently pending.");
            }
            Status = OrderStatus.Validated;
            PendingEndDate = DateTime.Now;
        }
        public void AddItem(ProductId productId, int quantity)
        {
            if (Status != OrderStatus.Open) {
                throw new InvalidOrderStatus("Cannot add order item if order is not currently open.");
            }

            var line = _lines.SingleOrDefault(orderLine => orderLine.ProductId == productId);
            if (line == null) {
                _lines.Add(new OrderLine(quantity, productId));
            }
            else {
                line.AddQuantity(quantity);
            }
        }
    }
}