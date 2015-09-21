using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;
using Try4Real.Client.Wpf.Presentation.Views;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class WindowFactory : DefaultWindowFactory
    {
        public override Window BuildNewWindow(IViewModelDialog viewModel)
        {
            if (viewModel is CreateNewOrderViewModel) {
                return new CreateNewOrderView();
            }
            return base.BuildNewWindow(viewModel);
        }
    }
}