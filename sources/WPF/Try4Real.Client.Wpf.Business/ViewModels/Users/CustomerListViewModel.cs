using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Mvvm.Async;
using Try4Real.Client.Wpf.Business.Dialog;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.ViewModels.Users
{
    public class CustomerListViewModel : LoadingViewModelBase, IViewModelTab
    {
        private readonly IMessenger _messenger;
        private readonly ICustomerListService _customerListService;
        private readonly IDialogService _dialogService;

        public string Title => "Customer list";
        public bool CanClose => false;
        public bool IsClosable => false;
        public ObservableCollection<CustomerListItem> Customers
        {
            get => GetNotifiableProperty<ObservableCollection<CustomerListItem>>("Customers");
            set => SetNotifiableProperty("Customers", value);
        }
        public CustomerListItem SelectedCustomer
        {
            get => GetNotifiableProperty<CustomerListItem>("SelectedCustomer");
            set => SetNotifiableProperty("SelectedCustomer", value);
        }
        public IAsyncCommand CreateCustomerCommand { get; }
        public IAsyncCommand RefreshCommand { get; }
        public IAsyncCommand<CustomerListItem> DeleteCustomerCommand { get; }
        public ICommand<CustomerListItem> DisplayCustomerDetailsCommand { get; }

        // ----- Constructors
        public CustomerListViewModel(
            IMessenger messenger,
            ICustomerListService customerListService,
            IDialogService dialogService)
        {
            _messenger = messenger;
            _customerListService = customerListService;
            _dialogService = dialogService;

            CreateCustomerCommand = new AsyncCommand(CreateCustomer);
            RefreshCommand = new AsyncCommand(RefreshCustomerList);
            DeleteCustomerCommand = new AsyncCommand<CustomerListItem>(DeleteCustomer);
            DisplayCustomerDetailsCommand = new Command<CustomerListItem>(DisplayCustomerDetails);
        }

        // ----- Overrides
        public async Task Boot()
        {
            await RefreshCustomerList();
        }

        // ----- Internal logics
        private async Task CreateCustomer()
        {
            var random = new Random((int) DateTime.Now.Ticks);

            _customerListService.CreateCustomer(
                "FirstName" + random.Next(0, 50),
                "LastName" + random.Next(0, 50),
                DateTime.Now.Subtract(TimeSpan.FromDays(random.Next(0, 50 * 365))),
                random.Next(100, 10000) + "@gmail.com");

            await RefreshCustomerList();
        }

        private async Task DeleteCustomer(CustomerListItem customerListItem)
        {
            var answer = _dialogService.AskQuestion("Delete customer", "Are you sure to delete the customer '" + customerListItem.FullName + "' ?");
            if (answer == Answers.Yes) {
                await Async(() => _customerListService.DeleteCustomer(customerListItem.Id));
                Customers.Remove(customerListItem);
            }
        }

        private void DisplayCustomerDetails(CustomerListItem customerListItem)
        {
            var item = customerListItem ?? SelectedCustomer;
            if (item != null) {
                _messenger.Send(new DisplayCustomerDetailsMessage(item.Id));
            }
        }

        private async Task RefreshCustomerList()
        {
            var customers = await Async(() => _customerListService.GetCustomers());
            Customers = new ObservableCollection<CustomerListItem>(customers);
        }
    }
}