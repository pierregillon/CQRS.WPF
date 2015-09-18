namespace Try4Real.Domain.Commands.Base
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}