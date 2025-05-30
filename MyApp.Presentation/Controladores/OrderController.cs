using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repository;

namespace OrderManagement.Presentation.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Metodo que permite crear ordenes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Customer request)
        {
            var customer = new Customer
            {
                Id = request.Id,
                Name = request.Name
            };

            var order = _orderService.CreateOrder(customer);

            return Ok(order);
        }
        /// <summary>
        /// Metodo que permite cancelar una orden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/cancel")]
        public IActionResult CancelOrder(Guid id)
        {
            var order = new Order
            {
                Id = id,
                Status = "Created"
            };

            _orderService.CancelOrder(order);

            return Ok(new { message = $"Orden {id} cancelada", status = order.Status });
        }
    }
}
