using System;

namespace Try4Real.EndPoint.Contracts
{
    public class CustomerListItem
    {
        public Guid Id { get; set; }
        public int YearOld { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}