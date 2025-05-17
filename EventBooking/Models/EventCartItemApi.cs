namespace EventBooking.Models
{
    public class EventCartItemApi
    {
        public int EventId { get; set; }
        public string UserId { get; set; }
        public string EventName { get; set; }
        public decimal Price { get; set; }
    }
}
