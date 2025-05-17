using EventBooking.Bl;
using EventBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventBooking.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        EventDbContext context;
        public BookingsController(UserManager<ApplicationUser> userManager, EventDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }
        [HttpPost]
        public ApiResponse Post([FromBody] EventCartItemApi Event)
        {
            try
            {
                SaveBooking(Event);
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = "done";
                oApiResponse.Errors = null;
                oApiResponse.StatusCode = "200";
                return oApiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;
            }
        }
        

        private async Task SaveBooking(EventCartItemApi Event)
        {
            try
            {
                var book = new Booking()
                {
                    UserId = Event.UserId,
                    BookingDate = DateTime.Now,
                    EventId = Event.EventId
                };
                context.Bookings.Add(book);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
