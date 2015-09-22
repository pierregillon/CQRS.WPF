using System;

namespace Try4Real.Client.Wpf.Business.ViewModels.Users
{
    public class OpenCustomerDetailsMessage
    {
        public Guid CustomerId { get; private set; }

        public OpenCustomerDetailsMessage(Guid customerId)
        {
            CustomerId = customerId;
        }

        public override bool Equals(object obj)
        {
            var message = obj as OpenCustomerDetailsMessage;
            if (message == null) {
                return base.Equals(obj);
            }
            return message.CustomerId == CustomerId;
        }
    }
}