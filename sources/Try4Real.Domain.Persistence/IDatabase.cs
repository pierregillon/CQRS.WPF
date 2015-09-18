using System.Collections.Generic;

namespace Try4Real.Domain.Infrastructure
{
    public interface IDatabase
    {
        IList<T> Set<T>();
    }
}