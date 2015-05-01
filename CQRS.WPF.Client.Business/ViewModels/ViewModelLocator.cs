using GalaSoft.MvvmLight.Ioc;

namespace CQRS.WPF.Client.Business.ViewModels
{
    public class ViewModelLocator
    {
        public CustomerListViewModel CustomerListViewModel
        {
            get { return SimpleIoc.Default.GetInstance<CustomerListViewModel>(); }
        }
    }
}
