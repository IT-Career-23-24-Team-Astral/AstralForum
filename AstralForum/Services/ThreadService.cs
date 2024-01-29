using AstralForum.Models.Category;

namespace AstralForum.Services
{
    public class ThreadService
    {
        //TODO...
        private readonly ApplicationDbContext context;

        public ThreadService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CategoryViewModel> GetCategory() => context.Category.Select(g => new CategoryViewModel
        {
            Id = g.Id,
            CategoryName = g.CategoryName
        }).ToList();
        
        public void Delete()
        {
            context.SaveChanges();
        }
    }
}
