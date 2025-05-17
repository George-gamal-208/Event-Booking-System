namespace EventBooking.Models
{
    public class EventCartItem
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
