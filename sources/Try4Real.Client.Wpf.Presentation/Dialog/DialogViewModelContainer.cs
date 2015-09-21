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
                element.OnViewModelChanged((IViewModelDialog)args.OldValue, (IViewModelDialog)args.NewValue);
            }
        }

        public event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;
        protected virtual void OnViewModelChanged(IViewModelDialog oldViewModel, IViewModelDialog newViewModel)
        {
            EventHandler<ViewModelChangedEventArgs> handler = ViewModelChanged;
            if (handler != null) handler(this, new ViewModelChangedEventArgs(oldViewModel, newViewModel));
        }

        public IViewModelDialog ViewModel
        {
            get { return (IViewModelDialog) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}