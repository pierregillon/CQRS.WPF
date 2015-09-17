using System.Collections.Generic;

namespace CQRS.WPF.CustomerManagement.Persistence
{
    public interface IDatabase
    {
        IList<T> Set<T>();
    }
}