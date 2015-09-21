using System.Collections.Generic;
using System.Linq;
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
        private readonly CustomerListViewModel _customerListViewModel;
        private readonly IEnumerable<CustomerListItem> SOME_CUSTOMERS = new List<CustomerListItem>
        {
            new CustomerListItem(),
            new CustomerListItem(),
        };
        private readonly CustomerListItem A_CUSTOMER = new CustomerListItem();

        private readonly Mock<ICustomerListService> _customerListServiceMock;
        private readonly Mock<IDialogService> _dialogServiceMock;
        private readonly Mock<IMessenger> _messengerServiceMock;

        public CustomerListViewModel_should()
        {
            _messengerServiceMock = new Mock<IMessenger>();
            _customerListServiceMock = new Mock<ICustomerListService>();
            _dialogServiceMock = new Mock<IDialogService>();

            _customerListViewModel = new CustomerListViewModel(_messengerServiceMock.Object, _customerListServiceMock.Object, _dialogServiceMock.Object);
        }

        [Fact]
        public void load_customers_from_the_customer_list_service_when_booting()
        {
            // Arrange
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(SOME_CUSTOMERS);

            // Acts
            _customerListViewModel.Boot().Wait();

            // Asserts
            Check.That(_customerListViewModel.Customers).Contains(SOME_CUSTOMERS);
        }

        [Fact]
        public void end_loading_when_boot_is_completed()
        {
            // Acts
            _customerListViewModel.Boot().Wait();

            // Asserts
            Check.That(_customerListViewModel.IsLoading).IsFalse();
        }

        [Fact]
        public void have_no_selected_customer_when_boot_is_completed()
        {
            // Acts
            _customerListViewModel.Boot().Wait();

            // Asserts
            Check.That(_customerListViewModel.SelectedCustomer).IsNull();
        }

        [Fact]
        public void send_a_message_to_display_customer_details_when_opening_customer_details()
        {
            // Arrange
            _customerListServiceMock.Setup(x => x.GetCustomers()).Returns(SOME_CUSTOMERS.Union(new[] {A_CUSTOMER}));

            // Acts
            _customerListViewModel.Boot().Wait();
            _customerListViewModel.OpenCustomerDetailsCommand.Execute(A_CUSTOMER);

            // Asserts
            _messengerServiceMock.Verify(x => x.Send(It.IsAny<OpenCustomerDetailsMessage>()), Times.Once);
        }
    }
}