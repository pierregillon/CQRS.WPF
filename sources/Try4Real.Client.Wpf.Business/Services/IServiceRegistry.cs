using SimpleInjector;

namespace Try4Real.Client.Wpf.Business.Services
{
    public interface IServiceRegistry
    {
        void RegisterService(Container container);
    }
}