namespace Try4Realse.Core.Application.Commands.Base
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}