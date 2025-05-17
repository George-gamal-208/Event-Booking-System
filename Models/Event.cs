using System.ComponentModel.DataAnnotations;

namespace EventBooking.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Event name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        [StringLength(200, ErrorMessage = "Venue cannot exceed 200 characters")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10,000")]
        public decimal Price { get; set; }
        public string? ImageUrl  { get; set; }
        public int CurrentState { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Booking> bookings { get; set; } = new List<Booking>();
    }
}
