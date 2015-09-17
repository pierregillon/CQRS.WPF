using CQRS.WPF.CustomerManagement.Application;
using CQRS.WPF.CustomerManagement.Application.Base;

namespace CQRS.WPF.EndPoint.Services
{
    public class Gate : IGate
    {
        public void Dispatch<T>(T command)
        {
            var handler = Ioc.Instance.GetInstance<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}