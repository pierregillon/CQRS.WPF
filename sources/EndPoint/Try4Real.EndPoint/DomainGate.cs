using System;
using SimpleInjector;
using Try4Real.Domain.Boostrapper;
using Try4Real.EndPoint.Contracts.Services;
using Try4Real.EndPoint.Services;

namespace Try4Real.EndPoint
{
    public class DomainGate
    {
        private readonly Container _container;

        public ICustomerService CustomerService => _container.GetInstance<ICustomerService>();
        public IOrderService OrderService => _container.GetInstance<IOrderService>();
        public IProductService ProductService => _container.GetInstance<IProductService>();

        public DomainGate()
        {
            _container = new Container();

            var domainRegistry = new Registry();

            domainRegistry.Register(_container);

            _container.Register<ICustomerService, CustomerService>();
            _container.Register<IOrderService, OrderService>();
            _container.Register<IProductService, ProductService>();
        }

        public object GetService(Type serviceType) => _container.GetInstance(serviceType);
    }
}