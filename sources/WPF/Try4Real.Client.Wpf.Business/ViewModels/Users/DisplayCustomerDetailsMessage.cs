using System;

namespace Try4Real.Client.Wpf.Business.ViewModels.Users
{
    public class DisplayCustomerDetailsMessage
    {
        public Guid CustomerId { get; }

        public DisplayCustomerDetailsMessage(Guid customerId) => CustomerId = customerId;

        public override bool Equals(object obj)
        {
            var message = obj as DisplayCustomerDetailsMessage;
            if (message == null) {
                return base.Equals(obj);
            }
            return message.CustomerId == CustomerId;
        }
    }
}