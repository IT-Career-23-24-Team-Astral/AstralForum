using Microsoft.EntityFrameworkCore;
using Thread = AstralForum.Data.Entities.Thread.Thread;

namespace AstralForum.Repositories
{
    public class ThreadRepository : CommonRepository<Data.Entities.Thread.Thread>
    {
        public ThreadRepository(ApplicationDbContext context) : base(context) { }

        public Thread GetThreadById(int id)
        {
            return context.Threads
                .Include(t => t.ThreadCategory)
                .Include(t => t.CreatedBy)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.CreatedBy)
                .Include(t => t.Reactions)
                .Include(t => t.Attachments)
                .Where(t => t.Id == id)
                .Single();
        }
        
        /*
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
