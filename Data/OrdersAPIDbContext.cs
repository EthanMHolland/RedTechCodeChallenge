using Microsoft.EntityFrameworkCore;

namespace OrdersAPI.Data
{
    public class OrdersAPIDbContext : DbContext
    {
        public OrdersAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
