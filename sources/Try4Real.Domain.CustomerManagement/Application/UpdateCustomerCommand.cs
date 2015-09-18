﻿using System;
using Try4Real.Domain.CustomerManagement.Domain;

namespace Try4Real.Domain.CustomerManagement.Application
{
    public class UpdateCustomerCommand
    {
        public CustomerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public UpdateCustomerCommand(CustomerId id, string firstName, string lastName, DateTime birthDate, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
        }
    }
}