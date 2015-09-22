using System;
using System.Threading.Tasks;

namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public class AsyncCommand : IAsyncCommand, System.Windows.Input.ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;
        public virtual void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        bool System.Windows.Input.ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }
        async void System.Windows.Input.ICommand.Execute(object parameter)
        {
            await ExecuteAsync();
        }

        public bool CanExecute()
        {
            if (_canExecute == null) {
                return true;
            }
            return _canExecute();
        }
        public Task ExecuteAsync()
        {
            return _execute();
        }
    }

    public class AsyncCommand<T> : IAsyncCommand<T>, System.Windows.Input.ICommand
    {
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;
        public virtual void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        bool System.Windows.Input.ICommand.CanExecute(object parameter)
        {
            return CanExecute((T) parameter);
        }
        async void System.Windows.Input.ICommand.Execute(object parameter)
        {
            await ExecuteAsync((T) parameter);
        }

        public bool CanExecute(T parameter)
        {
            if (_canExecute == null) {
                return true;
            }
            return _canExecute(parameter);
        }
        public Task ExecuteAsync(T parameter)
        {
            return _execute(parameter);
        }
    }
}