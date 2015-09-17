using System.Windows;
using Try4Real.Client.Wpf.Business;
using Try4Real.Client.Wpf.Business.ViewModels;

namespace Try4Real.Client.Wpf.Presentation
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
#if DEBUG
            Ioc.Instance.Init(new LocalDataAccess.ServiceRegistry());
#else
            Ioc.Instance.Init(new RemoteDataAccess.ServiceRegistry());
#endif
            ((ViewModelLocator)Current.Resources["Locator"]).MainViewModel.Boot();
        }
    }
}
