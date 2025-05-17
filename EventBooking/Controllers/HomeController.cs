using EventBooking.Bl;
using EventBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventBooking.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IEvents Events, ICategories categories)
        {
            oClsEvents = Events;
            oClsCategories = categories;
        }
        IEvents oClsEvents;
        ICategories oClsCategories;
        /*public IActionResult Index()
        {
            var Events = oClsEvents.GetAll();
            return View(Events);
        }*/
        public async Task<IActionResult> Index(int page = 1, int pageSize = 6)
        {
            var pagedEvents = await oClsEvents.GetPagedAsync(page, pageSize);
            return View(pagedEvents); // Pass PagedResult<Event> instead of IEnumerable<Event>
        }
    }
}
