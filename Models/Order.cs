namespace OrdersAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderType Type { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUsername { get; set; }
    }

    public enum OrderType
    {
        Standard,
        SaleOrder,
        PurchaseOrder,
        TransferOrder,
        ReturnOrder
    }
}
