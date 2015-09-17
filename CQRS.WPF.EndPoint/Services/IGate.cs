namespace CQRS.WPF.EndPoint.Services
{
    public interface IGate
    {
        void Dispatch<T>(T command);
    }
}