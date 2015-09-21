using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public interface IWindowFactory
    {
        Window BuildNewWindow(IViewModelDialog viewModel);
    }
}