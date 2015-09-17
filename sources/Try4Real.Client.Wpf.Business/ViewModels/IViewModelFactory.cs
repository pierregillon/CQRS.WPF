namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public interface IViewModelFactory<out TViewModel>
    {
        TViewModel Build();
    }
}