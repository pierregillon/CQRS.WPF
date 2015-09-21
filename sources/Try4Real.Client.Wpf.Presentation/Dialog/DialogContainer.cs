using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DialogContainer : FrameworkElement
    {
        public static readonly DependencyProperty DialogsProperty = DependencyProperty.Register(
            "Dialogs", typeof (ObservableCollection<DialogViewModelContainer>), typeof (DialogContainer), new PropertyMetadata(new ObservableCollection<DialogViewModelContainer>()));

        // ----- Fields
        private readonly IDictionary<IViewModelDialog, Window> _windows = new Dictionary<IViewModelDialog, Window>();

        // ----- Properties
        public ObservableCollection<DialogViewModelContainer> Dialogs
        {
            get { return (ObservableCollection<DialogViewModelContainer>) GetValue(DialogsProperty); }
            set { SetValue(DialogsProperty, value); }
        }

        // ----- Constructors
        public DialogContainer()
        {
            Dialogs = new ObservableCollection<DialogViewModelContainer>();
            Dialogs.CollectionChanged += DialogsOnCollectionChanged;
        }

        // ----- Event callbacks
        private void DialogsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            DialogViewModelContainer container;

            switch (args.Action) {
                case NotifyCollectionChangedAction.Add:
                    container = (DialogViewModelContainer) args.NewItems[0];
                    if (container.ViewModel != null) {
                        SubscribeToVisibilityChanged(container.ViewModel);
                    }
                    container.ViewModelChanged += ContainerOnViewModelChanged;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    container = (DialogViewModelContainer) args.OldItems[0];
                    container.ViewModelChanged -= ContainerOnViewModelChanged;
                    if (container.ViewModel != null) {
                        UnsubscribeToVisibilityChanged(container.ViewModel);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Reset:
                case NotifyCollectionChangedAction.Move:
                    break;
                default:
                    throw new Exception("The actio is not managed.");
            }
        }
        private void ContainerOnViewModelChanged(object sender, ViewModelChangedEventArgs eventArgs)
        {
            if (eventArgs.OldViewModel != null) {
                UnsubscribeToVisibilityChanged(eventArgs.OldViewModel);
            }
            if (eventArgs.NewViewModel != null) {
                SubscribeToVisibilityChanged(eventArgs.NewViewModel);
            }
        }
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
                CloseDialogWith(viewModel);
            }
        }

        // ----- Private methods.
        private void OpenDialogWith(IViewModelDialog viewModel)
        {
            var window = new Window();
            window.Closed += (sender, args) => { viewModel.IsVisible = false; };
            window.DataContext = viewModel;
            _windows.Add(viewModel, window);
            window.ShowDialog();
        }
        private void CloseDialogWith(IViewModelDialog viewModel)
        {
            var window = _windows[viewModel];
            _windows.Remove(viewModel);
            window.Close();
        }
    }
}