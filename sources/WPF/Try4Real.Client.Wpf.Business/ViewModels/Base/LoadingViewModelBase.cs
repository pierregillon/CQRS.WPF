using System;
using System.Threading.Tasks;

namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public abstract class LoadingViewModelBase : ViewModelBase
    {
        public bool IsLoading
        {
            get => GetNotifiableProperty<bool>("IsLoading");
            protected set => SetNotifiableProperty("IsLoading", value);
        }

        protected async Task<T> Async<T>(Func<T> task)
        {
            try {
                IsLoading = true;
                return await Task.Run(task);
            }
            finally {
                IsLoading = false;
            }
        }

        protected async Task Async(Action action)
        {
            try {
                IsLoading = true;
                await Task.Run(action);
            }
            finally {
                IsLoading = false;
            }
        }
    }
}