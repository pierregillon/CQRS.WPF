using System.ComponentModel;
using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DialogViewModelContainer : FrameworkElement
    {
        // ----- Dependency properties
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof (IViewModelDialog), typeof (DialogViewModelContainer), new PropertyMetadata(default(IViewModelDialog), ViewModelPropertyChangedCallback));

        public static readonly DependencyProperty ViewFactoryProperty = DependencyProperty.Register(
            "ViewFactory", typeof(IWindowFactory), typeof(DialogViewModelContainer), new PropertyMetadata(default(IWindowFactory)));

        private static void ViewModelPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var element = dependencyObject as DialogViewModelContainer;
            if (element != null)
            {
                if (args.OldValue != null)
                {
                    element.UnsubscribeToVisibilityChanged((IViewModelDialog)args.OldValue);
                }
                if (args.NewValue != null)
                {
                    element.SubscribeToVisibilityChanged((IViewModelDialog)args.NewValue);
                }
            }
        }

        // ----- Fields
        private Window _window;

        // ----- Properties
        public IViewModelDialog ViewModel
        {
            get { return (IViewModelDialog)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public IWindowFactory ViewFactory
        {
            get { return (IWindowFactory) GetValue(ViewFactoryProperty); }
            set { SetValue(ViewFactoryProperty, value); }
        }

        // ----- Event callbacks
        private void SubscribeToVisibilityChanged(INotifyPropertyChanged viewModel)
        {
            viewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }
        private void UnsubscribeToVisibilityChanged(INotifyPropertyChanged viewModel)
        {
            viewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        }
        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "IsVisible") {
                return;
            }
            ViewModelOnVisibilityChanged((IViewModelDialog) sender);
        }
        private void ViewModelOnVisibilityChanged(IViewModelDialog viewModel)
        {
            if (viewModel.IsVisible) {
                OpenDialogWith(viewModel);
            }
            else {
                CloseCurrentWindow();
            }
        }

        // ----- Private methods.
        private void OpenDialogWith(IViewModelDialog viewModel)
        {
            var window = ViewFactory.BuildNewWindow(viewModel);
            window.DataContext = viewModel;
            window.Closed += (sender, args) => { viewModel.IsVisible = false; };
            _window = window;
            window.ShowDialog();
        }
        private void CloseCurrentWindow()
        {
            if (_window != null) {
                _window.Close();
                _window = null;
            }
        }
    }
}