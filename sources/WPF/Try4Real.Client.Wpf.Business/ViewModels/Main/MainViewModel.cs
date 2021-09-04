using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.Client.Wpf.Business.ViewModels.Orders;
using Try4Real.Client.Wpf.Business.ViewModels.Users;

namespace Try4Real.Client.Wpf.Business.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewModelFactory<CustomerListViewModel> _customerListViewModelFactory;
        private readonly IViewModelFactory<CustomerDetailViewModel> _customerDetailViewModelFactory;
        private readonly IViewModelFactory<OrderListViewModel> _orderListViewModelFactory;

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
        public ICommand<IViewModelTab> CloseTabCommand { get; private set; }

        public MainViewModel(
            IMessenger messenger, 
            IViewModelFactory<CustomerListViewModel> customerListViewModelFactory, 
            IViewModelFactory<CustomerDetailViewModel> customerDetailViewModelFactory,
            IViewModelFactory<OrderListViewModel> orderListViewModelFactory)
        {
            _customerListViewModelFactory = customerListViewModelFactory;
            _customerDetailViewModelFactory = customerDetailViewModelFactory;
            _orderListViewModelFactory = orderListViewModelFactory;

            Tabs = new ObservableCollection<IViewModelTab>();
            CloseTabCommand = new Command<IViewModelTab>(CloseTab);

            messenger.Register<DisplayCustomerDetailsMessage>(this, OpenCustomerDetailsMessageReceived);
        }

        public async Task Boot()
        {
            var customerListViewModel = _customerListViewModelFactory.Build();
            Tabs.Add(customerListViewModel);
            await customerListViewModel.Boot();

            var orderListViewModel = _orderListViewModelFactory.Build();
            Tabs.Add(orderListViewModel);
            await orderListViewModel.Boot();
        }

        private void CloseTab(IViewModelTab viewModelTab)
        {
            Tabs.Remove(viewModelTab);
        }

        private async void OpenCustomerDetailsMessageReceived(DisplayCustomerDetailsMessage displayCustomerDetailsMessage)
        {
            var detailViewModel = _customerDetailViewModelFactory.Build();
            Tabs.Add(detailViewModel);
            SelectedTab = detailViewModel;
            await detailViewModel.Boot(displayCustomerDetailsMessage.CustomerId);
        }
    }
}