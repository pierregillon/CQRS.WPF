using System;
using SimpleInjector;
using Try4Real.Domain.Boostrapper;
using Try4Real.EndPoint.Contracts.Services;
using Try4Real.EndPoint.Services;

namespace Try4Real.EndPoint
{
    public class DomainEntry
    {
        private readonly Container _container;

        public ICustomerService CustomerService
        {
            get { return _container.GetInstance<ICustomerService>(); }
        }
        public IOrderService OrderService
        {
            get { return _container.GetInstance<IOrderService>(); }
        }
        public IProductService ProductService
        {
            get { return _container.GetInstance<IProductService>(); }
        }

        public DomainEntry()
        {
            _container = new Container();

            var domainRegistry = new Registry();
            domainRegistry.Register(_container);

            _container.Register<ICustomerService, CustomerService>();
            _container.Register<IOrderService, OrderService>();
            _container.Register<IProductService, ProductService>();
        }
        
        public object GetService(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }
    }
}