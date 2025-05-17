using EventBooking.Bl;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.Controllers
{
    public class EventController : Controller
    {
        public EventController(IEvents Events, ICategories categories)
        {
            oClsEvents = Events;
            oClsCategories = categories;
        }
        IEvents oClsEvents;
        ICategories oClsCategories;

        public IActionResult EventDetails(int id)
        {
            var Event = oClsEvents.GetEventId(id);
            return View(Event);
        }
    }
}
