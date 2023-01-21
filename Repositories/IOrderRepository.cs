using OrdersAPI.Models;

namespace OrdersAPI.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(Guid id);
        void CreateOrder(CreateOrderRequest createOrderRequest);
        void UpdateOrder(Guid id, UpdateOrderRequest updateOrderRequest);
        void DeleteOrder(Guid id);
        IEnumerable<Order> SearchByOrderType(int orderType);
        void Save();
    }
}
