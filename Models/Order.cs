namespace OrdersAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Type OrderType { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUsername { get; set; }
    }
}
