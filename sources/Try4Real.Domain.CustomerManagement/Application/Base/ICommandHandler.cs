namespace Try4Real.Domain.CustomerManagement.Application.Base
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}