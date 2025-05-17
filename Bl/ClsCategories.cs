using EventBooking.Models;
namespace EventBooking.Bl
{
    public interface ICategories
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public bool Save(Category category);
        public bool Delete(int id);
    }

    public class ClsCategories : ICategories
    {
        EventDbContext context;
        public ClsCategories(EventDbContext ctx)
        {
            context = ctx;
        }
        public List<Category> GetAll()
        {
            try
            {
                var lstCategories = context.Categories.Where(a=>a.CurrentState==1).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<Category>();
            }
        }

        public Category GetById(int id)
        {
            try
            {
                var category = context.Categories.FirstOrDefault(a => a.CategoryId == id && a.CurrentState==1);
                return category;
            }
            catch
            {
                return new Category();
            }
        }

        public bool Save(Category category)
        {
            try
            {
                if (category.CategoryId == 0)
                {
                    context.Categories.Add(category);
                }
                else
                {
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var category = GetById(id);
                category.CurrentState = 0;
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
