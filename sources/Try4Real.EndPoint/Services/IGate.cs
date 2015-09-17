namespace Try4Real.EndPoint.Services
{
    public interface IGate
    {
        void Dispatch<T>(T command);
    }
}