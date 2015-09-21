using GalaSoft.MvvmLight.Messaging;
using Try4Real.Client.Wpf.Business.ViewModels.Base;

namespace Try4Real.Client.Wpf.Business.ViewModels
{
    public class CreateNewOrderViewModel : LoadingViewModelBase, IViewModelDialog
    {
        public bool IsVisible
        {
            get { return GetNotifiableProperty<bool>("IsVisible"); }
            set { SetNotifiableProperty("IsVisible", value); }
        }

        public CreateNewOrderViewModel(IMessenger messenger)
        {
            messenger.Register<CreateNewOrderMessage>(this, CreateNewOrderMessageReceived);
        }

        private void CreateNewOrderMessageReceived(CreateNewOrderMessage createNewOrderMessage)
        {
            IsVisible = true;
        }
    }
}