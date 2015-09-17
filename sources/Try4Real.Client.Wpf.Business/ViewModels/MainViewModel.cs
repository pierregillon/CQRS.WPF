using System.Collections.ObjectModel;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICustomerListService _customerListService;

        public ObservableCollection<IViewModelTab> Tabs
        {
            get { return GetNotifiableProperty<ObservableCollection<IViewModelTab>>("Tabs"); }
            private set { SetNotifiableProperty("Tabs", value); }
        }
        public IViewModelTab SelectedTab
        {
            get { return GetNotifiableProperty<IViewModelTab>("SelectedTab"); }
            set { SetNotifiableProperty("SelectedTab", value); }
        }

        public MainViewModel(ICustomerListService customerListService)
        {
            _customerListService = customerListService;
            Tabs = new ObservableCollection<IViewModelTab>();
        }

        public void Boot()
        {
            Tabs.Add(new CustomerListViewModel(_customerListService));
        }
    }
}