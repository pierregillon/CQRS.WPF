using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public interface IWindowFactory
    {
        Window BuildNewWindow(IViewModelDialog viewModel);
    }
}