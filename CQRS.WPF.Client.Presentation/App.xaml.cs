using System.Windows;
using CQRS.WPF.Client.Business;
using CQRS.WPF.Client.Business.ViewModels;
using CQRS.WPF.Client.LocalDataAccess;

namespace CQRS.WPF.Client.Presentation
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Instance.Init(new ServiceRegistry());

            ((ViewModelLocator)Current.Resources["Locator"]).CustomerListViewModel.Boot();
        }
    }
}
