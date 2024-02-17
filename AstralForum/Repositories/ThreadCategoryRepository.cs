using AstralForum.Data.Entities;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models;
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
        public void AddThreadCategory(ThreadCategoryModel model, User id)
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
        public ThreadCategoryModel CategoryDetails(int id)
        {
            var category = context.ThreadCategory.Where(c => c.Id == id).Select(c => new ThreadCategoryModel()
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                CreatedById = c.CreatedById,
                CreatedOn = c.CreatedOn,
            }).FirstOrDefault();
            return category;
        }
        public List<ThreadCategoryModel> GetAllThreadGategories()
        {
            return context.ThreadCategory.Select(c => new ThreadCategoryModel()
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            }).ToList();
        }
        public void Edit(ThreadCategory threadCategory, ThreadCategoryModel model)
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
