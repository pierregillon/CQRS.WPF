using System.Linq;
using SimpleInjector;
using Try4Real.Domain.Commands.Base;

namespace Try4Real.EndPoint.Services
{
    public class Gate : IGate
    {
        private readonly Container _container;

        public Gate(Container container)
        {
            _container = container;
        }

        public void Dispatch<T>(T command)
        {
            var handler = _container.GetAllInstances<ICommandHandler<T>>().Single();
            handler.Handle(command);
        }
    }
}