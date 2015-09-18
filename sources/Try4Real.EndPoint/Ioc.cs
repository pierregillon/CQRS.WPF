using System;
using SimpleInjector;
using SimpleInjector.Extensions;
using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Infrastructure;
using Try4Real.Domain.Infrastructure.Finders;
using Try4Real.Domain.Infrastructure.Repositories;
using Try4Real.Domain.Model.User;
using Try4Real.Domain.Presentation;
using Try4Real.EndPoint.Contracts.Services;
using Try4Real.EndPoint.Services;

namespace Try4Real.EndPoint
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
            _container.Register<IGate, Gate>();
            _container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            _container.Register<IDatabase, InMemoryDatabase>(Lifestyle.Singleton);
        }
        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
        public object GetInstance(Type type)
        {
            return _container.GetInstance(type);
        }
    }
}