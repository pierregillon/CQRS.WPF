﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Mvvm.Async;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.ViewModels.Orders
{
    public class OrderListViewModel : LoadingViewModelBase, IViewModelTab
    {
        private readonly IMessenger _messenger;
        private readonly IOrderListService _orderListService;

        public string Title
        {
            get { return "Order list"; }
        }
        public bool CanClose
        {
            get { return false; }
        }
        public ObservableCollection<OrderListItem> Orders
        {
            get { return GetNotifiableProperty<ObservableCollection<OrderListItem>>("Orders"); }
            private set { SetNotifiableProperty("Orders", value); }
        }
        public OrderListItem SelectedOrder
        {
            get { return GetNotifiableProperty<OrderListItem>("SelectedOrder"); }
            set { SetNotifiableProperty("SelectedOrder", value); }
        }

        public ICommand CreateOrderCommand { get; private set; }
        public IAsyncCommand RefreshCommand { get; private set; }
        public ICommand OpenOrderDetailCommand { private set; get; }

        public OrderListViewModel(IMessenger messenger, IOrderListService orderListService)
        {
            _messenger = messenger;
            _orderListService = orderListService;
            Orders = new ObservableCollection<OrderListItem>();

            CreateOrderCommand = new Command(CreateOrder);
            RefreshCommand = new AsyncCommand(Refresh);
        }

        public async Task Boot()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            var orderListItems = await Async(() => _orderListService.GetOrders());
            Orders = new ObservableCollection<OrderListItem>(orderListItems);
        }
        private void CreateOrder()
        {
            _messenger.Send(new CreateNewOrderMessage());
        }
    }
}