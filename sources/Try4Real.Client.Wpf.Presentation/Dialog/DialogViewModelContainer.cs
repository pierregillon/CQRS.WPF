using System;
using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DialogViewModelContainer : FrameworkElement
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof (IViewModelDialog), typeof (DialogViewModelContainer), new PropertyMetadata(default(IViewModelDialog), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var element = dependencyObject as DialogViewModelContainer;
            if (element != null) {
                element.OnViewModelChanged();
            }
        }

        public event EventHandler ViewModelChanged;
        protected virtual void OnViewModelChanged()
        {
            EventHandler handler = ViewModelChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public IViewModelDialog ViewModel
        {
            get { return (IViewModelDialog) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}