using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;
using OrdersAPI.Repositories;

namespace OrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = orderRepository.GetOrders();
            
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetOrderById([FromRoute] Guid id)
        {
            var order = orderRepository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);

        }


        [HttpPost]
        public IActionResult CreateOrder(CreateOrderRequest createOrderRequest)
        {
            orderRepository.CreateOrder(createOrderRequest);
            orderRepository.Save();
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateOrder([FromRoute] Guid id, UpdateOrderRequest updateOrderRequest)
        {
            orderRepository.UpdateOrder(id, updateOrderRequest);
            orderRepository.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteOrder([FromRoute] Guid id)
        {
            orderRepository.DeleteOrder(id);
            orderRepository.Save();
            return Ok();
            
        }
    }
}
