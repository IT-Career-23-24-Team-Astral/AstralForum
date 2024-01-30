using AstralForum.Models.Category;

namespace AstralForum.Repositories
{
    public class ThreadRepository
    {
        private readonly ApplicationDbContext context;

        public ThreadRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CategoryViewModel> GetCategory() => context.Category.Select(g => new CategoryViewModel
        {
            Id = g.Id,
            CategoryName = g.CategoryName
        }).ToList();

        //public void Delete()
        //{
        //    context.SaveChanges();
        //}
    }
}
