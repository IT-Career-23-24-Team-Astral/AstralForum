using AstralForum.Data.Entities;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
	public class ThreadCategoryRepository : CommonRepository<ThreadCategory>
	{
		public ThreadCategoryRepository(ApplicationDbContext context) : base(context) { }

		public ThreadCategory GetThreadCategoryById(int id)
		{
			return context.ThreadCategories
				.Include(t => t.CreatedBy)
				.Include(t => t.Threads)
					.ThenInclude(t => t.CreatedBy)
                .Single(t => t.Id == id);


        }

		/*public void AddThreadCategory(ThreadCategoryModel model, User id)
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
        }*/
	}
}