using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using Try4Real.Client.Wpf.Business.Services;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly ICustomerListService _customerListService;
        private readonly ICustomerDetailService _customerDetailService;

        public ObservableCollection<IViewModelTab> Tabs
        {
            get { return GetNotifiableProperty<ObservableCollection<IViewModelTab>>("Tabs"); }
            private set { SetNotifiableProperty("Tabs", value); }
        }
        public IViewModelTab SelectedTab
        {
            get { return GetNotifiableProperty<IViewModelTab>("SelectedTab"); }
            set { SetNotifiableProperty("SelectedTab", value); }
        }

        public MainViewModel(IMessenger messenger, ICustomerListService customerListService, ICustomerDetailService customerDetailService)
        {
            _messenger = messenger;
            _customerListService = customerListService;
            _customerDetailService = customerDetailService;
            Tabs = new ObservableCollection<IViewModelTab>();

            _messenger.Register<OpenCustomerDetailsMessage>(this, OpenCustomerDetailsMessageReceived);
        }

        public void Boot()
        {
            Tabs.Add(new CustomerListViewModel(_messenger, _customerListService));
        }

        private void OpenCustomerDetailsMessageReceived(OpenCustomerDetailsMessage openCustomerDetailsMessage)
        {
            var detailViewModel = new CustomerDetailViewModel(_customerDetailService);
            detailViewModel.Boot(openCustomerDetailsMessage.CustomerId);
            Tabs.Add(detailViewModel);
            SelectedTab = detailViewModel;
        }
    }
}