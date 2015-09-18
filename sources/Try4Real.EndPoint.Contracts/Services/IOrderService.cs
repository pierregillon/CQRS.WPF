using System.ServiceModel;

namespace Try4Real.EndPoint.Contracts.Services
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        void CreateOrder(CreateOrderRequest request);
    }
}