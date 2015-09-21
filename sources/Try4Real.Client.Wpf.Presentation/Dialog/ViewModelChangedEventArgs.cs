using System;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class ViewModelChangedEventArgs : EventArgs
    {
        public IViewModelDialog OldViewModel { get; private set; }
        public IViewModelDialog NewViewModel { get; private set; }

        public ViewModelChangedEventArgs(IViewModelDialog oldViewModel, IViewModelDialog newViewModel)
        {
            OldViewModel = oldViewModel;
            NewViewModel = newViewModel;
        }
    }
}