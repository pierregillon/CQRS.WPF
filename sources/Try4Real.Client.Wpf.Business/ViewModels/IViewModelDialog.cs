using System.ComponentModel;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public interface IViewModelDialog : INotifyPropertyChanged
    {
        bool IsVisible { get; set; }
    }
}