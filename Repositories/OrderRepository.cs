using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Models;

namespace OrdersAPI.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly OrdersAPIDbContext _context;

        public OrderRepository(OrdersAPIDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(Guid id)
        {
            return _context.Orders.Find(id);
        }

        public void CreateOrder(CreateOrderRequest createOrderRequest)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Type = createOrderRequest.Type,
                CustomerName = createOrderRequest.CustomerName,
                CreatedDate = DateTime.Now,
                CreatedByUsername = createOrderRequest.CreatedByUsername

            };
            _context.Orders.Add(order);
        }

        public void UpdateOrder(Guid id, UpdateOrderRequest updateOrderRequest)
        {
            var order =  _context.Orders.Find(id);
            if (order != null)
            {
                order.Type = updateOrderRequest.Type;
                order.CustomerName = updateOrderRequest.CustomerName;
                order.CreatedByUsername = updateOrderRequest.CreatedByUsername;
            }
            
        }

        public void DeleteOrder(Guid id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
