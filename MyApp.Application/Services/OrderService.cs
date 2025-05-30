using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain;

namespace Prueba.Application.Services
{
    public class OrderService
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