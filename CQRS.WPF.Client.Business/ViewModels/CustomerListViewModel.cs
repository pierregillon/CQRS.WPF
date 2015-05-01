using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CQRS.WPF.Client.Business.Services;
using CQRS.WPF.Client.Business.ViewModels.Base;
using CQRS.WPF.EndPoint.Contracts;
using GalaSoft.MvvmLight.Command;

namespace CQRS.WPF.Client.Business.ViewModels
{
    public class CustomerListViewModel : LoadingViewModelBase
    {
        private readonly ICustomerListService _customerListService;

        public string TabHeader
        {
            get { return "Customer list"; }
        }
        public bool IsClosable { get { return false; } }
        public ObservableCollection<CustomerListItem> Customers
        {
            get { return GetNotifiableProperty<ObservableCollection<CustomerListItem>>("Customers"); }
            set { SetNotifiableProperty("Customers", value); }
        }
        public CustomerListItem SelectedCustomer
        {
            get { return GetNotifiableProperty<CustomerListItem>("SelectedCustomer"); }
            set { SetNotifiableProperty("SelectedCustomer", value); }
        }
        public ICommand CreateCustomerCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCustomerCommand { get; private set; }
        public ICommand OpenCustomerDetailsCommand { get; private set; }

        // ----- Constructors
        public CustomerListViewModel(ICustomerListService customerListService)
        {
            _customerListService = customerListService;
            CreateCustomerCommand = new RelayCommand(CreateCustomer);
            RefreshCommand = new RelayCommand(RefreshCustomerList);
            DeleteCustomerCommand = new RelayCommand<CustomerListItem>(DeleteCustomer);
            OpenCustomerDetailsCommand = new RelayCommand(OpenCustomerDetails, CanOpenCustomerDetails);
        }

        // ----- Overrides
        public void Boot()
        {
            RefreshCustomerList();
        }

        // ----- Internal logics
        private void CreateCustomer()
        {
            var random = new Random((int) DateTime.Now.Ticks);
            //_customerListService.CreateCustomer(
            //    random.Next(100, 10000).ToString(),
            //    random.Next(100, 10000).ToString(),
            //    DateTime.Now,
            //    random.Next(100, 10000) + "@gmail.com");
            RefreshCustomerList();
        }
        private void DeleteCustomer(CustomerListItem customerListItemViewModel)
        {
            //_customerListService.DeleteCustomer(customerListItemViewModel.Id);
            Customers.Remove(customerListItemViewModel);
        }
        private bool CanOpenCustomerDetails()
        {
            return SelectedCustomer != null;
        }
        private void OpenCustomerDetails()
        {
            //Messenger.Default.Send(new OpenCustomerDetailsMessage(SelectedCustomer.Id));
        }
        private async void RefreshCustomerList()
        {
            var customers = await Async(() => _customerListService.GetCustomers());
            Customers = new ObservableCollection<CustomerListItem>(customers);
        }
    }
}