using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrdersAPI.Models;

namespace OrdersAPI.Data
{
    public class OrdersAPIDbContext : DbContext
    {
        public OrdersAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
