

using OrderManagement.Application.Services;
using OrderManagement.Domain;

namespace OrderManagement.Test
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_ShouldInitializeOrderCorrectly()
        {
            var service = new OrderService();
            var customer = new Customer { Id = Guid.NewGuid(), Name = "Juan", Email = "juan@example.com" };

            var order = service.CreateOrder(customer);

            Assert.Equal(customer.Id, order.CustomerId);
            Assert.Equal("Created", order.Status);
        }

        [Fact]
        public void CancelOrder_ShouldSetStatusToCancelled()
        {
            var service = new OrderService();
            var order = new Order();

            service.CancelOrder(order);

            Assert.Equal("Cancelled", order.Status);
        }
    }
}