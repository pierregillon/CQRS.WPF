namespace CQRS.WPF.CustomerManagement.Application.Base
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}