using Try4Real.Domain.CustomerManagement.Application.Base;

namespace Try4Real.EndPoint.Services
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