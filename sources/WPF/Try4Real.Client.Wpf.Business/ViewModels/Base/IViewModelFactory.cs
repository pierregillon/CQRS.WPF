namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public interface IViewModelFactory<out TViewModel>
    {
        TViewModel Build();
    }
}