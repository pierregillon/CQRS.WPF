using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Business.ViewModels
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
        public ICommand CloseTabCommand { get; private set; }

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
            CloseTabCommand = new RelayCommand<IViewModelTab>(CloseTab);

            messenger.Register<OpenCustomerDetailsMessage>(this, OpenCustomerDetailsMessageReceived);
        }

        public void Boot()
        {
            var customerListViewModel = _customerListViewModelFactory.Build();
            Tabs.Add(customerListViewModel);
            customerListViewModel.Boot();

            var orderListViewModel = _orderListViewModelFactory.Build();
            Tabs.Add(orderListViewModel);
            orderListViewModel.Boot();
        }

        private void CloseTab(IViewModelTab viewModelTab)
        {
            Tabs.Remove(viewModelTab);
        }
        private void OpenCustomerDetailsMessageReceived(OpenCustomerDetailsMessage openCustomerDetailsMessage)
        {
            var detailViewModel = _customerDetailViewModelFactory.Build();
            detailViewModel.Boot(openCustomerDetailsMessage.CustomerId);
            Tabs.Add(detailViewModel);
            SelectedTab = detailViewModel;
        }
    }
}