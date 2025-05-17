using EventBooking.Models;
using EventBooking.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace EventBooking.Bl
{
    public interface IEvents
    {
        public List<Event> GetAll();
        Task<PagedResult<Event>> GetPagedAsync(int page, int pageSize);
        public List<VwEvent> GetAllEventsData();
        public Event GetById(int id);
        public EventDetailsModel GetEventId(int id);
        public List<EventDetailsModel> GetEventsData();
        public bool Save(Event Event);
        public bool Delete(int id);
    }
    public class ClsEvents : IEvents
    {
        EventDbContext context;
        public ClsEvents(EventDbContext ctx)
        {
            context = ctx;
        }
        public List<Event> GetAll()
        {
            try
            {

                var events = context.Events.Where(a=>a.CurrentState==1).ToList();
                return events;
            }
            catch
            {
                return new List<Event>();
            }
        }
        public async Task<PagedResult<Event>> GetPagedAsync(int page, int pageSize)
        {
            var query = context.Events
                .Where(a => a.CurrentState == 1); // Apply the condition
            var totalItems = await query.CountAsync();

            var items = await query
                .OrderBy(e => e.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Event>
            {
                Items = items,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
        
        public List<VwEvent> GetAllEventsData()
        {
            try
            {
                var query = from d in context.Events
                            join c in context.Categories
                            on d.CategoryId equals c.CategoryId
                            where d.CurrentState == 1
                            select new VwEvent
                            {
                                Id=d.EventId,
                                Name = d.Name,
                                Date = d.Date,
                                Venue = d.Venue,
                                Price = d.Price,
                                CategoryName = c.CategoryName
                            };
                return query.ToList();
            }
            catch
            {
                return new List<VwEvent>();
            }
        }
        public Event GetById(int id)
        {
            try
            {
                var item = context.Events.FirstOrDefault(a => a.EventId == id && a.CurrentState == 1);
                return item;
            }
            catch
            {
                return new Event();
            }
        }
        public EventDetailsModel GetEventId(int id)
        {
            try
            {
                var result = (from d in context.Events
                              join c in context.Categories
                              on d.CategoryId equals c.CategoryId
                              where d.CurrentState == 1 && d.EventId == id
                              select new EventDetailsModel
                              {
                                  EventId=d.EventId,
                                  Name = d.Name,
                                  Date = d.Date,
                                  Venue = d.Venue,
                                  Price = d.Price,
                                  CategoryName = c.CategoryName,
                                  Description = d.Description,
                                  ImageUrl = d.ImageUrl
                              }).FirstOrDefault();

                return result ?? new EventDetailsModel();
            }
            catch
            {
                return new EventDetailsModel();
            }
        }

        public List<EventDetailsModel> GetEventsData()
        {
            try
            {
                var result = (from d in context.Events
                              join c in context.Categories
                              on d.CategoryId equals c.CategoryId
                              where d.CurrentState == 1 
                              select new EventDetailsModel
                              {
                                  EventId = d.EventId,
                                  Name = d.Name,
                                  Date = d.Date,
                                  Venue = d.Venue,
                                  Price = d.Price,
                                  CategoryName = c.CategoryName,
                                  Description = d.Description,
                                  ImageUrl = d.ImageUrl
                              });

                return result.ToList();
            }
            catch
            {
                return new List<EventDetailsModel>();
            }
        }
        public bool Save(Event Event)
        {
            try
            {
                if (Event.EventId == 0)
                {
                    Event.CurrentState = 1;
                    context.Events.Add(Event);
                }
                else
                {
                    context.Entry(Event).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var Event = GetById(id);
                Event.CurrentState = 0;
                context.Entry(Event).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
