using System;

namespace Try4Real.Domain.Model.Order
{
    public class InvalidOrderStatus : Exception
    {
        public InvalidOrderStatus(string message) : base(message)
        {
            
        }
    }
}