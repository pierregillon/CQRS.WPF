using System;
using System.Collections;
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
        // ----- Initialization

        public CustomerListViewModel_should()
        {
            _messengerServiceMock = new Mock<IMessenger>();
            _customerListServiceMock = new Mock<ICustomerListService>();
            _dialogServiceMock = new Mock<IDialogService>();

            _customerListViewModel = new CustomerListViewModel(_messengerServiceMock.Object, _customerListServiceMock.Object, _dialogServiceMock.Object);
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(INITIAL_CUSTOMERS);
            _customerListViewModel.Boot().Wait();
        }

        // ----- Tests

        [Fact]
        public void be_a_unclosable_tab()
        {
            Check.That(_customerListViewModel.CanClose).IsFalse();
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

        [Fact]
        public void displays_customers_from_the_customer_list_service_when_booted()
        {
            Check.That(_customerListViewModel.Customers).Contains(INITIAL_CUSTOMERS);
        }

        [Fact]
        public void have_no_selected_customer_when_booted()
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
        public void be_loading_when_refreshing_the_displayed_customers()
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
        public void ask_confirmation_when_deleting_customer()
        {
            var customerToDelete = INITIAL_CUSTOMERS.First();
            customerToDelete.FullName = "MARTIN jean";

            _customerListViewModel.DeleteCustomerCommand.ExecuteAsync(customerToDelete);

            _dialogServiceMock.Verify(x=> x.AskQuestion(
                "Delete customer", 
                "Are you sure to delete the customer 'MARTIN jean' ?"
            ), Times.Once);
        }

        [Fact]
        public void remove_customer_from_list_when_validating_the_delete_confirmation()
        {
            // Arrange
            var customerToDelete = INITIAL_CUSTOMERS.First();

            _dialogServiceMock
                .Setup(x => x.AskQuestion(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Answers.Yes);

            // Acts
            _customerListViewModel.DeleteCustomerCommand.ExecuteAsync(customerToDelete).Wait();


            // Asserts
            Check.That(_customerListViewModel.Customers).Not.Contains(customerToDelete);
        }

        [Fact]
        public void call_delete_customer_service_when_validating_the_delete_confirmation()
        {
            // Arrange
            var customerToDelete = INITIAL_CUSTOMERS.First();

            _dialogServiceMock
                .Setup(x => x.AskQuestion(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Answers.Yes);

            // Acts
            _customerListViewModel.DeleteCustomerCommand.ExecuteAsync(customerToDelete).Wait();

            // Asserts
            _customerListServiceMock.Verify(x=>x.DeleteCustomer(customerToDelete.Id), Times.Once);
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

        // ----- Fields
        private readonly CustomerListViewModel _customerListViewModel;
        private readonly Mock<ICustomerListService> _customerListServiceMock;
        private readonly Mock<IDialogService> _dialogServiceMock;
        private readonly Mock<IMessenger> _messengerServiceMock;

        // ----- Data
        private readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
        private readonly IEnumerable<CustomerListItem> SOME_CUSTOMERS = new List<CustomerListItem>
        {
            new CustomerListItem(),
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
        private readonly IEnumerable<CustomerListItem> INITIAL_CUSTOMERS = new[]
        {
            new CustomerListItem{Id = Guid.NewGuid()},
            new CustomerListItem(),
        };
        private readonly CustomerListItem A_CUSTOMER = new CustomerListItem { Id = Guid.NewGuid() };
    }
}