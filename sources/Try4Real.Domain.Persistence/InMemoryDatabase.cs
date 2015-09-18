using System;
using System.Collections;
using System.Collections.Generic;

namespace Try4Real.Domain.Infrastructure
{
    public class InMemoryDatabase : IDatabase
    {
        private readonly IDictionary<Type, IEnumerable> _data = new Dictionary<Type, IEnumerable>();

        public IList<T> Set<T>()
        {
            if (_data.ContainsKey(typeof (T)) == false) {
                _data.Add(typeof (T), new List<T>());
            }
            return (IList<T>) _data[typeof (T)];
        }
    }
}