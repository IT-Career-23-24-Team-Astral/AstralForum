using AstralForum.Data.Entities.ThreadCategory;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class ThreadRepository :CommonRepository<Data.Entities.Thread.Thread>
    {
        public ThreadRepository(ApplicationDbContext context) : base(context) { }
        public async Task<List<Data.Entities.Thread.Thread>> GetThreadsByThreadCategoryId(int id)
        {
            ThreadCategory category =  await context.ThreadCategory
                .Include(e => e.Threads)
                .FirstAsync(p => p.Id == id);

            return category.Threads;
        }
        /*public void AddThread(ThreadModel model, User id)
        {
            Post thread = new Post()
            {
                Title = model.Title,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                ThreadCategoryId = model.ThreadCategory,
                CreatedById = model.CreatedById
            };
            context.Threads.Add(thread);
            context.SaveChanges();
        }
        public List<ThreadModel> GetAllThreadsByThreadCategory(int ThreadCategory)
        {
            return context.Threads.Where(x => x.ThreadCategoryId == ThreadCategory).Select(x => new ThreadModel()
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                ImageUrl = x.ImageUrl,
                CreatedById = x.CreatedById,
                CreatedOn = x.CreatedOn
            }).ToList();
        }
        public void Edit(Post thread, ThreadModel model)
        {
            thread.Title = model.Title;
            thread.Text = model.Text;
            thread.ImageUrl = model.ImageUrl;
            thread.ThreadCategoryId = model.ThreadCategory;
            context.Threads.Update(thread);
            context.SaveChanges();
        }
        public void Delete(Post thread)
        {
            context.Threads.Remove(thread);
            context.SaveChanges();
        }*/
    }
}
