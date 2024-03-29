﻿using Try4Real.Domain.User;

namespace Try4Realse.Core.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public CustomerId Id { get; }

        public DeleteCustomerCommand(CustomerId id) => Id = id;
    }
}