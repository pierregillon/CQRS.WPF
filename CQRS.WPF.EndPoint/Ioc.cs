using CQRS.WPF.CustomerManagement.Infrastructure;
using CQRS.WPF.CustomerManagement.Persistence.Finders;
using CQRS.WPF.CustomerManagement.Persistence.Repositories;
using CQRS.WPF.CustomerManagement.Presentation;
using CQRS.WPF.EndPoint.Contracts;
using CQRS.WPF.EndPoint.Services;
using SimpleInjector;

namespace CQRS.WPF.EndPoint
{
    public class Ioc
    {
        private static readonly Ioc _instance = new Ioc();
        public static Ioc Instance
        {
            get { return _instance; }
        }

        private readonly Container _container = new Container();

        public void Init()
        {
            _container.Register<ICustomerService, CustomerService>();
            _container.Register<ICustomerListFinder, CustomerListFinder>();
            _container.Register<ICustomerRepository, CustomerRepository>();
        }
        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}