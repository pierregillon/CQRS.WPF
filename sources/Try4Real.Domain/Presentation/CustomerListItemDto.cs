using System;

namespace Try4Real.Domain.Presentation
{
    public class CustomerListItemDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int YearOld { get; set; }
        public string Email { get; set; }
    }
}