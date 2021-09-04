using System;
using System.Threading.Tasks;
using Mvvm.Async;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;
using Try4Real.EndPoint.Contracts;

namespace Try4Real.Client.Wpf.Business.ViewModels.Users
{
    public class CustomerDetailViewModel : LoadingViewModelBase, IViewModelTab
    {
        private readonly ICustomerDetailService _customerDetailService;
        private Guid _id;

        public string Title
        {
            get => GetNotifiableProperty<string>("Title");
            private set => SetNotifiableProperty("Title", value);
        }
        public bool CanClose => true;
        public string CustomerFirstName
        {
            get => GetNotifiableProperty<string>("CustomerFirstName");
            set => SetNotifiableProperty("CustomerFirstName", value);
        }
        public string CustomerLastName
        {
            get => GetNotifiableProperty<string>("CustomerLastName");
            set => SetNotifiableProperty("CustomerLastName", value);
        }
        public DateTime CustomerBirthDate
        {
            get => GetNotifiableProperty<DateTime>("CustomerBirthDate");
            set => SetNotifiableProperty("CustomerBirthDate", value);
        }
        public string CustomerEmail
        {
            get => GetNotifiableProperty<string>("CustomerEmail");
            set => SetNotifiableProperty("CustomerEmail", value);
        }

        public IAsyncCommand SaveCommand { get; }

        public CustomerDetailViewModel(ICustomerDetailService customerDetailService)
        {
            _customerDetailService = customerDetailService;

            SaveCommand = new AsyncCommand(Save);
        }

        public async Task Boot(Guid customerId)
        {
            Title = "Customer detail";
            var customerDetails = await Async(() => _customerDetailService.GetCustomerDetails(customerId));

            _id = customerDetails.Id;
            Title = customerDetails.FirstName + " " + customerDetails.LastName;
            CustomerFirstName = customerDetails.FirstName;
            CustomerLastName = customerDetails.LastName;
            CustomerBirthDate = customerDetails.BirthDate;
            CustomerEmail = customerDetails.Email;
        }

        private async Task Save()
        {
            await Async(() => _customerDetailService.UpdateDetails(new CustomerDetails {
                Id = _id,
                FirstName = CustomerFirstName,
                LastName = CustomerLastName,
                BirthDate = CustomerBirthDate,
                Email = CustomerEmail
            }));
        }
    }
}