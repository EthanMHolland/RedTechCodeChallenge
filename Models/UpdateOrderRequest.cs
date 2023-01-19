namespace OrdersAPI.Models
{
    public class UpdateOrderRequest
    {
        public string OrderType { get; set; }
        public string CustomerName { get; set; }
        public string CreatedByUsername { get; set; }
    }
}
