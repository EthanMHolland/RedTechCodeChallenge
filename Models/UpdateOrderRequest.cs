namespace OrdersAPI.Models
{
    public class UpdateOrderRequest
    {
        public OrderType Type { get; set; }
        public string CustomerName { get; set; }
        public string CreatedByUsername { get; set; }
    }
}
