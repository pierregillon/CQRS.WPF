using System;

namespace Try4Real.Domain.Order
{
    public class InvalidOrderStatus : Exception
    {
        public InvalidOrderStatus(string message) : base(message) { }
    }
}