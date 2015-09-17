namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public interface IViewModelTab
    {
        string Title { get; }
        bool CanClose { get; }
    }
}