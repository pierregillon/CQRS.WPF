using System.Collections.ObjectModel;
using System.Windows;

namespace Try4Real.Client.Wpf.Presentation.Dialog
{
    public class DialogContainer : FrameworkElement
    {
        public static readonly DependencyProperty DialogsProperty = DependencyProperty.Register(
            "Dialogs", typeof(ObservableCollection<DialogViewModelContainer>), typeof(DialogContainer), new PropertyMetadata(new ObservableCollection<DialogViewModelContainer>()));

        // ----- Properties
        public ObservableCollection<DialogViewModelContainer> Dialogs
        {
            get => (ObservableCollection<DialogViewModelContainer>) GetValue(DialogsProperty);
            set => SetValue(DialogsProperty, value);
        }

        // ----- Constructors
        public DialogContainer() => Dialogs = new ObservableCollection<DialogViewModelContainer>();
    }
}