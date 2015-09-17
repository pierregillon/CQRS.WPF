using System;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class CustomerDetailViewModel : LoadingViewModelBase, IViewModelTab
    {
        private readonly ICustomerDetailService _customerDetailService;

        public string Title
        {
            get { return GetNotifiableProperty<string>("Title"); }
            private set { SetNotifiableProperty("Title", value); }
        }
        public bool CanClose { get { return true; } }

        public CustomerDetailViewModel(ICustomerDetailService customerDetailService)
        {
            _customerDetailService = customerDetailService;
        }

        public async void Boot(Guid customerId)
        {
            Title = "Customer detail";
            var customerDetails = await Async(() => _customerDetailService.GetCustomerDetails(customerId));
            Title = customerDetails.FirstName + " " + customerDetails.LastName;
        }
    }
}
