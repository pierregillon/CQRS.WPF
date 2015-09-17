using System;
using Try4Real.Domain.CustomerManagement.Application.Base;

namespace Try4Real.Domain.CustomerManagement.Application
{
    public class CreateCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public CreateCustomerCommand(string firstName, string lastName, DateTime birthDate, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
        }
    }
}