namespace Try4Real.Domain.Boostrapper
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command);
    }
}