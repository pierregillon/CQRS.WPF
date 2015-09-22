using System;

namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public class Command : ICommand, System.Windows.Input.ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;
        public virtual void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public Command(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute()
        {
            if (_canExecute == null) {
                return true;
            }
            return _canExecute();
        }
        public void Execute()
        {
            _execute();
        }
        bool System.Windows.Input.ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }
        void System.Windows.Input.ICommand.Execute(object parameter)
        {
            Execute();
        }
    }

    public class Command<T> : ICommand<T>, System.Windows.Input.ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;
        public virtual void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public Command(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(T parameter)
        {
            if (_canExecute == null) {
                return true;
            }
            return _canExecute(parameter);
        }
        public void Execute(T parameter)
        {
            _execute(parameter);
        }
        bool System.Windows.Input.ICommand.CanExecute(object parameter)
        {
            return CanExecute((T) parameter);
        }
        void System.Windows.Input.ICommand.Execute(object parameter)
        {
            Execute((T) parameter);
        }
    }
}