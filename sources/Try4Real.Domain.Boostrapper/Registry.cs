using SimpleInjector;
using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Infrastructure;
using Try4Real.Domain.Infrastructure.Finders;
using Try4Real.Domain.Infrastructure.Repositories;
using Try4Real.Domain.Model.Order;
using Try4Real.Domain.Model.User;
using Try4Real.Domain.Presentation;

namespace Try4Real.Domain.Boostrapper
{
    public class Registry
    {
        public void Register(Container container)
        {
            container.Register<ICustomerListFinder, CustomerListFinder>();
            container.Register<IOrderListFinder, OrderListFinder>();
            container.Register<IProductFinder, ProductFinder>();

            container.Register<ICustomerRepository, CustomerRepository>();
            container.Register<IOrderRepository, OrderRepository>();

            container.RegisterCollection(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            container.Register<ICommandDispatcher, CommandDispatcher>();
            container.Register<IDatabase, InMemoryDatabase>(Lifestyle.Singleton);
        }
    }
}
