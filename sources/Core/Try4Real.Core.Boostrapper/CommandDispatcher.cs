using System.Linq;
using SimpleInjector;
using Try4Realse.Core.Application.Commands._Base;

namespace Try4Real.Domain.Boostrapper
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;

        public CommandDispatcher(Container container) => _container = container;

        public void Dispatch<T>(T command)
        {
            var handler = _container.GetAllInstances<ICommandHandler<T>>().Single();
            handler.Handle(command);
        }
    }
}