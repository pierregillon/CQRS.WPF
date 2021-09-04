using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mvvm.Async;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.ViewModels.Orders
{
    public class CreateNewOrderViewModel : LoadingViewModelBase, IViewModelDialog
    {
        private readonly ICustomerListService _customerListService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductListService _productListService;

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
        public ObservableCollection<OrderItemViewModel> OrderItems
        {
            get { return GetNotifiableProperty<ObservableCollection<OrderItemViewModel>>("OrderItems"); }
            private set { SetNotifiableProperty("OrderItems", value); }
        }
        public IEnumerable<ProductListItem> Products
        {
            get { return GetNotifiableProperty<IEnumerable<ProductListItem>>("Products"); }
            set { SetNotifiableProperty("Products", value); }
        }
        public ICommand CreateNewOrderItemCommand { get; private set; }
        public IAsyncCommand SaveCommand { get; private set; }

        public CreateNewOrderViewModel(
            IMessenger messenger, 
            ICustomerListService customerListService, 
            IOrderDetailService orderDetailService,
            IProductListService productListService)
        {
            _customerListService = customerListService;
            _orderDetailService = orderDetailService;
            _productListService = productListService;

            CreateNewOrderItemCommand = new Command(CreateNewOrder);
            SaveCommand = new AsyncCommand(Save);

            messenger.Register<CreateNewOrderMessage>(this, CreateNewOrderMessageReceived);
        }

        public async Task Boot()
        {
            OrderItems = new ObservableCollection<OrderItemViewModel>();
            
            var customerTask = Async(() => _customerListService.GetCustomers());
            var productTask = Async(() => _productListService.GetProducts());

            await Async(() => Task.WaitAll(customerTask, productTask));

            Customers = customerTask.Result;
            Products = productTask.Result;
        }

        private void CreateNewOrder()
        {
            OrderItems.Add(new OrderItemViewModel());
        }
        private async Task Save()
        {
            var orderItems = OrderItems.Select(x => new OrderItem(x.Product.Id, x.Amount)).ToArray();
            await Async(() => _orderDetailService.CreateOrder(SelectedCustomer.Id, orderItems));
            IsVisible = false;
        }

        private async void CreateNewOrderMessageReceived(CreateNewOrderMessage createNewOrderMessage)
        {
            await Boot();
            IsVisible = true;
        }
    }
}