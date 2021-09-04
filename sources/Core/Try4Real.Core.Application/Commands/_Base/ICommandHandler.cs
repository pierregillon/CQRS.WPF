namespace Try4Realse.Core.Application.Commands._Base
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}