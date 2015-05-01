using System.Windows;
using CQRS.WPF.Client.Business;
using CQRS.WPF.Client.Business.ViewModels;

namespace CQRS.WPF.Client.Presentation
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
            ((ViewModelLocator)Current.Resources["Locator"]).CustomerListViewModel.Boot();
        }
    }
}
