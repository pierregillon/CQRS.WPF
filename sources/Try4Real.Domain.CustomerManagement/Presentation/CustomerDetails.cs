using System;

namespace Try4Real.Domain.CustomerManagement.Presentation
{
    public class CustomerDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}