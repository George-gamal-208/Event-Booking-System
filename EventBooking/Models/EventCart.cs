namespace EventBooking.Models
{
    public class EventCart
    {
        public EventCart()
        {
            lstEvents = new List<EventCartItem>();
        }

        public List<EventCartItem> lstEvents { get; set; }
        public decimal Total { get; set; }
    }
}
