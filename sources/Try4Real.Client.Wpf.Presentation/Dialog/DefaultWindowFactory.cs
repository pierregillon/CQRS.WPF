using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DefaultWindowFactory : FrameworkElement, IWindowFactory
    {
        public virtual Window BuildNewWindow(IViewModelDialog viewModel)
        {
            return new Window();
        }
    }
}