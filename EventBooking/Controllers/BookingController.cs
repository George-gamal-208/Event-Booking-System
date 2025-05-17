using Microsoft.AspNetCore.Mvc;
using EventBooking.Models;
using EventBooking.Bl;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EventBooking.Controllers
{
    public class BookingController : Controller
    {
        IEvents eventService;
        UserManager<ApplicationUser> _userManager;
        EventDbContext context;
        public BookingController(IEvents eventservice, UserManager<ApplicationUser> userManager, EventDbContext ctx)
        {
            eventService = eventservice;
            _userManager = userManager;
            context = ctx;
        }

        [Authorize]
        public async Task<IActionResult> BookingSuccess()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            var cart = JsonConvert.DeserializeObject<EventCart>(sesstionCart);
            
            
            await SaveBooking(cart);
            return View(cart);
        }

        public IActionResult AddToCart(int eventId)
        {
            EventCart cart;

            if (HttpContext.Request.Cookies["Cart"] != null)
                cart = JsonConvert.DeserializeObject<EventCart>(HttpContext.Request.Cookies["Cart"]);
            else
                cart = new EventCart();

            var Event = eventService.GetById(eventId);

            var eventInList = cart.lstEvents.Where(a => a.EventId == eventId).FirstOrDefault();

            if (eventInList != null)
            {
                eventInList.Qty++;
                eventInList.Total = eventInList.Qty * eventInList.Price;
            }
            else
            {
                cart.lstEvents.Add(new EventCartItem
                {
                    EventId = Event.EventId,
                    EventName = Event.Name,
                    Price = Event.Price,
                    Qty = 1,
                    Total = Event.Price
                });
            }
            cart.Total = cart.lstEvents.Sum(a => a.Total);

            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("BookingSuccess");
        }

        public async Task SaveBooking(EventCart eventCart)
        {
            try
            {
                var Event = eventCart.lstEvents.LastOrDefault();
                var user = await _userManager.GetUserAsync(User);
                var book = new Booking()
                {
                    UserId = user.Id,
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
