using System;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class ViewModelChangedEventArgs : EventArgs
    {
        public IViewModelDialog OldViewModel { get; }
        public IViewModelDialog NewViewModel { get; }

        public ViewModelChangedEventArgs(IViewModelDialog oldViewModel, IViewModelDialog newViewModel)
        {
            OldViewModel = oldViewModel;
            NewViewModel = newViewModel;
        }
    }
}