namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public interface IViewModelTab
    {
        string Title { get; }
        bool CanClose { get; }
    }
}