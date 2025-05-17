using Microsoft.AspNetCore.Mvc;
using EventBooking.Bl;
using EventBooking.Models;
using EventBooking.Utlities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
namespace EventBooking.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class EventController : Controller
    {
        public EventController(IEvents Events, ICategories categories)
        {
            oClsEvents = Events;
            oClsCategories = categories;
        }
        IEvents oClsEvents;
        ICategories oClsCategories;
        public IActionResult List()
        {
            var Events = oClsEvents.GetAllEventsData();
            return View(Events);
        }
        public IActionResult Edit(int? eventId)
        {
            var Event = new Models.Event();
            ViewBag.lstCategories = oClsCategories.GetAll();
            if (eventId != null)
            {
                Event = oClsEvents.GetById(Convert.ToInt32(eventId));
            }
            return View(Event);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Event Event, List<IFormFile> Files)
        {
            
            if (!ModelState.IsValid)
                return View("Edit", Event);

            Event.ImageUrl = await Helper.UploadImage(Files, "Events");

            oClsEvents.Save(Event);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int eventId)
        {
            oClsEvents.Delete(eventId);
            return RedirectToAction("List");
        }
    }
}
