using System;

namespace Try4Real.Domain.CustomerManagement.Domain
{
    public class Customer
    {
        public CustomerId CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; set; }
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
        public void Rename(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}