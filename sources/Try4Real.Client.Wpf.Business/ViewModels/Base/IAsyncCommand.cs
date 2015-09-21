using System.Threading.Tasks;

namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public interface IAsyncCommand
    {
        bool CanExecute();
        Task ExecuteAsync();
    }

    public interface IAsyncCommand<in T>
    {
        bool CanExecute(T parameter);
        Task ExecuteAsync(T parameter);
    }
}