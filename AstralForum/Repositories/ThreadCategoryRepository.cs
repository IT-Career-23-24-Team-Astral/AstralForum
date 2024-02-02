using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models.Category;
using AstralForum.Models.Thread;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class ThreadCategoryRepository : CommonRepository<ThreadCategory>, IThreadCategoryRepository
    {
        private readonly ApplicationDbContext context;
        public ThreadCategoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public void AddThreadCategory(ThreadCategoryFormModel model, User id)
        {
            ThreadCategory category = new ThreadCategory()
            {
                Id = model.Id,
                CategoryName = model.CategoryName,
                CreatedById = id.Id
            };
            context.ThreadCategory.Add(category);
            context.SaveChanges();
        }
        public ThreadCategoryViewModel CategoryDetails(int id)
        {
            var category = context.ThreadCategory.Where(c => c.Id == id).Select(c => new ThreadCategoryViewModel()
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                CreatedById = c.CreatedById,
                CreatedOn = c.CreatedOn,
            }).FirstOrDefault();
            return category;
        }
        public List<ThreadCategoryViewModel> GetAllThreadGategories()
        {
            return context.ThreadCategory.Select(c => new ThreadCategoryViewModel()
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            }).ToList();
        }
        public void Edit(ThreadCategory threadCategory, ThreadCategoryFormModel model)
        {
            threadCategory.CategoryName = model.CategoryName;
            context.ThreadCategory.Update(threadCategory);
            context.SaveChanges();
        }
        public void Delete(ThreadCategory threadCategory)
        {
            context.ThreadCategory.Remove(threadCategory);
            context.SaveChanges();
        }
    }
}
