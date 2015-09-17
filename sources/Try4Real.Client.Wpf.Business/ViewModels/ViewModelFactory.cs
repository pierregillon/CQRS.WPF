namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class ViewModelFactory<T> : IViewModelFactory<T> where T : class
    {
        public T Build()
        {
            return Ioc.Instance.GetInstance<T>();
        }
    }
}