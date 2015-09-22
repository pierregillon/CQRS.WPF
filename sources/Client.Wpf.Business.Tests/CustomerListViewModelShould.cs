using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Moq;
using NFluent;
using Try4Real.Client.Wpf.Business.Dialog;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Users;
using Try4Real.EndPoint.Contracts;
using Xunit;

namespace Client.Wpf.Business.Tests
{
    public class CustomerListViewModel_should
    {
        private readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
        private CustomerListViewModel _customerListViewModel;
        private readonly IEnumerable<CustomerListItem> SOME_CUSTOMERS = new List<CustomerListItem>
        {
            new CustomerListItem(),
            new CustomerListItem(),
        };

        private readonly IEnumerable<CustomerListItem> SOME_OTHER_CUSTOMERS = new[]
        {
            new CustomerListItem(),
            new CustomerListItem(),
            new CustomerListItem(),
            new CustomerListItem(),
        };
        private readonly CustomerListItem A_CUSTOMER = new CustomerListItem{Id = Guid.NewGuid()};

        private readonly Mock<ICustomerListService> _customerListServiceMock;
        private readonly Mock<IDialogService> _dialogServiceMock;
        private readonly Mock<IMessenger> _messengerServiceMock;

        public CustomerListViewModel_should()
        {
            _messengerServiceMock = new Mock<IMessenger>();
            _customerListServiceMock = new Mock<ICustomerListService>();
            _dialogServiceMock = new Mock<IDialogService>();

            _customerListViewModel = new CustomerListViewModel(_messengerServiceMock.Object, _customerListServiceMock.Object, _dialogServiceMock.Object);
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(SOME_CUSTOMERS);
            _customerListViewModel.Boot().Wait();
        }

        [Fact]
        public void load_customers_from_the_customer_list_service_when_booted()
        {
            Check.That(_customerListViewModel.Customers).Contains(SOME_CUSTOMERS);
        }

        [Fact]
        public void end_loading_when_boot_is_completed()
        {
            // Arrange
            _customerListViewModel = new CustomerListViewModel(_messengerServiceMock.Object, _customerListServiceMock.Object, _dialogServiceMock.Object);

            // Acts
            _customerListViewModel.Boot().Wait();

            // Asserts
            Check.That(_customerListViewModel.IsLoading).IsFalse();
        }

        [Fact]
        public void have_no_selected_customer_when_boot_is_completed()
        {
            Check.That(_customerListViewModel.SelectedCustomer).IsNull();
        }

        [Fact]
        public void send_a_message_to_display_customer_details_when_opening_customer_details()
        {
            // Arrange
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(SOME_CUSTOMERS.Union(new[] {A_CUSTOMER}));
            var expectedMessage = new DisplayCustomerDetailsMessage(A_CUSTOMER.Id);

            // Acts
            _customerListViewModel.Boot().Wait();
            _customerListViewModel.DisplayCustomerDetailsCommand.Execute(A_CUSTOMER);

            // Asserts
            _messengerServiceMock.Verify(x => x.Send(expectedMessage), Times.Once);
        }

        [Fact]
        public void be_a_unclosable_tab()
        {
            Check.That(_customerListViewModel.CanClose).IsFalse();
        }

        [Fact]
        public void update_the_displayed_customers_when_refresh_invoked()
        {
            // Arrange
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(SOME_OTHER_CUSTOMERS);

            // Acts
            _customerListViewModel.RefreshCommand.ExecuteAsync().Wait();

            // Asserts
            Check.That(_customerListViewModel.Customers).Contains(SOME_OTHER_CUSTOMERS);
        }

        [Fact]
        public void load_when_refreshing_the_displayed_customers()
        {
            // Arrange
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(() =>
            {
                Wait();
                return SOME_OTHER_CUSTOMERS;
            });

            // Acts
            var refreshTask =_customerListViewModel.RefreshCommand.ExecuteAsync();
            
            // Asserts
            Check.That(_customerListViewModel.IsLoading).IsTrue();
            EndLoad(refreshTask);
            Check.That(_customerListViewModel.IsLoading).IsFalse();
        }

        [Fact]
        public void be_loading_when_booting()
        {
            // Arrange
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(() =>
            {
                Wait();
                return SOME_OTHER_CUSTOMERS;
            });

            // Acts
            var bootTask = _customerListViewModel.Boot();
 
            // Asserts
            Check.That(_customerListViewModel.IsLoading).IsTrue();
            EndLoad(bootTask);
            Check.That(_customerListViewModel.IsLoading).IsFalse();
        }

        // ----- Private methods
        private void Wait()
        {
            _manualResetEvent.WaitOne();
        }
        private void EndLoad(Task bootTask)
        {
            _manualResetEvent.Set();
            bootTask.Wait();
        }
    }
}