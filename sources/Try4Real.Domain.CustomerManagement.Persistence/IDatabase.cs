using System.Collections.Generic;

namespace Try4Real.Domain.CustomerManagement.Infrastructure
{
    public interface IDatabase
    {
        IList<T> Set<T>();
    }
}