namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public interface ICommand
    {
        bool CanExecute();
        void Execute();
    }

    public interface ICommand<in T>
    {
        bool CanExecute(T parameter);
        void Execute(T parameter);
    }
}