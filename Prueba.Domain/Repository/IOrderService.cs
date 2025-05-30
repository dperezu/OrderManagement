using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Repository
{
    public interface IOrderService
    {
        void CancelOrder(Order order);
        Order CreateOrder(Customer customer);
    }
}