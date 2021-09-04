using System.ComponentModel;

namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public interface IViewModelDialog : INotifyPropertyChanged
    {
        bool IsVisible { get; set; }
    }
}