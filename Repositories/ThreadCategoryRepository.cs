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
			ThreadCategory category = context.ThreadCategories
				.Include(category => category.CreatedBy)
				.Include(category => category.Threads)
					.ThenInclude(thread => thread.CreatedBy)
				.Include(category => category.Threads)
					.ThenInclude(thread => thread.Comments)
						.ThenInclude(comment => comment.CreatedBy)
				.Where(c => c.Id == id)
				.Single(); 

			return category;
		}
    }
}
