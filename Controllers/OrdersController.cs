using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;

namespace OrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrdersAPIDbContext dbContext;

        public OrdersController(OrdersAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await dbContext.Orders.ToListAsync();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOrder([FromRoute] Guid id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);

        }


        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderRequest addOrderRequest)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                OrderType = addOrderRequest.OrderType,
                CustomerName = addOrderRequest.CustomerName,
                CreatedDate = DateTime.Now,
                CreatedByUsername = addOrderRequest.CreatedByUsername

            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return Ok(order);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, UpdateOrderRequest updateOrderRequest)
        {
            var order = await dbContext.Orders.FindAsync(id);
            if (order != null)
            {
                order.OrderType = updateOrderRequest.OrderType;
                order.CustomerName = updateOrderRequest.CustomerName;
                order.CreatedByUsername = updateOrderRequest.CreatedByUsername;

                await dbContext.SaveChangesAsync();

                return Ok(order);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order != null)
            {
                dbContext.Orders.Remove(order);
                await dbContext.SaveChangesAsync();
                return Ok(order);
            }
            return NotFound();
        }
    }
}
