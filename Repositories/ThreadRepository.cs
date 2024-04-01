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
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Reactions)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Attachments)
                .Include(t => t.Reactions)
                .Include(t => t.Attachments)
                .Where(t => t.Id == id)
                .Single();
        }
		



	}

}