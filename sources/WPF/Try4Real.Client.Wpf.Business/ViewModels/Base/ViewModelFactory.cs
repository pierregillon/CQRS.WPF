namespace Try4Real.Client.Wpf.Business.ViewModels.Base
{
    public class ViewModelFactory<T> : IViewModelFactory<T> where T : class
    {
        public T Build() => Ioc.Instance.GetInstance<T>();
    }
}