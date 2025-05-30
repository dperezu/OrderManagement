using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repository;

namespace OrderManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        public Order CreateOrder(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            return new Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.UtcNow,
                Status = "Created"
            };
        }

        public void CancelOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            order.Status = "Cancelled";
        }
    }
}