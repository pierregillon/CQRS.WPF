using System.Windows;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DefaultWindowFactory : FrameworkElement, IWindowFactory
    {
        public Window BuildNewWindow()
        {
            return new Window();
        }
    }
}