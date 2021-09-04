using System;
using System.Collections;
using System.Collections.Generic;
using Try4Real.Domain.ProductCatalog;
using Try4Real.Domain.User;

namespace Try4Real.Domain.Infrastructure
{
    public class InMemoryDatabase : IDatabase
    {
        private readonly IDictionary<Type, IEnumerable> _data = new Dictionary<Type, IEnumerable>();

        public InMemoryDatabase()
        {
            var customer = new Customer("Mark", "DUPONT", DateTime.Now.Subtract(TimeSpan.FromDays(25*365)));
            var order = new Order.Order(customer.CustomerId);

            Set<Customer>().Add(customer);
            Set<Order.Order>().Add(order);

            Set<Product>().Add(new Product("Jacket"));
            Set<Product>().Add(new Product("Book"));
        }

        public IList<T> Set<T>()
        {
            if (_data.ContainsKey(typeof (T)) == false) {
                _data.Add(typeof (T), new List<T>());
            }
            return (IList<T>) _data[typeof (T)];
        }
    }
}