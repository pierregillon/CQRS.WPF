using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class CreateNewOrderViewModel : LoadingViewModelBase, IViewModelDialog
    {
        private readonly ICustomerListService _customerListService;
        private readonly IOrderDetailService _orderDetailService;

        public bool IsVisible
        {
            get { return GetNotifiableProperty<bool>("IsVisible"); }
            set { SetNotifiableProperty("IsVisible", value); }
        }
        public IEnumerable<CustomerListItem> Customers
        {
            get { return GetNotifiableProperty<IEnumerable<CustomerListItem>>("Customers"); }
            private set { SetNotifiableProperty("Customers", value); }
        }
        public CustomerListItem SelectedCustomer
        {
            get { return GetNotifiableProperty<CustomerListItem>("SelectedCustomer"); }
            set { SetNotifiableProperty("SelectedCustomer", value); }
        }
        public ObservableCollection<OrderItem> OrderItems
        {
            get { return GetNotifiableProperty<ObservableCollection<OrderItem>>("OrderItems"); }
            private set { SetNotifiableProperty("OrderItems", value); }
        }
        public ICommand CreateNewOrderItemCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public CreateNewOrderViewModel(IMessenger messenger, ICustomerListService customerListService, IOrderDetailService orderDetailService)
        {
            _customerListService = customerListService;
            _orderDetailService = orderDetailService;

            CreateNewOrderItemCommand = new RelayCommand(CreateNewOrder);
            SaveCommand = new RelayCommand(Save);

            messenger.Register<CreateNewOrderMessage>(this, CreateNewOrderMessageReceived);
        }

        public async void Boot()
        {
            Customers = await Async(() => _customerListService.GetCustomers());
            OrderItems = new ObservableCollection<OrderItem>();
        }

        private void CreateNewOrder()
        {
            OrderItems.Add(new OrderItem());
        }
        private async void Save()
        {
            await Async(() => _orderDetailService.CreateOrder(SelectedCustomer.Id, OrderItems));
            IsVisible = false;
        }

        private void CreateNewOrderMessageReceived(CreateNewOrderMessage createNewOrderMessage)
        {
            Boot();
            IsVisible = true;
        }
    }
}