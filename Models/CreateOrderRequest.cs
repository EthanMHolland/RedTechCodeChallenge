namespace OrdersAPI.Models
{
    public class CreateOrderRequest
    {
        public OrderType Type { get; set; }
        public string CustomerName { get; set; }
        public string CreatedByUsername { get; set; }
    }
}
