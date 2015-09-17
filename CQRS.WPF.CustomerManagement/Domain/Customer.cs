using System;

namespace CQRS.WPF.CustomerManagement.Domain
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public string Email { get; private set; }

        public Customer()
        {
            CustomerId = CustomerId.New();
        }
        public Customer(string firstName, string lastName, DateTime birthDate) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }
    }
}