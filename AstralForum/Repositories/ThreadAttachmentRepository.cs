using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class ThreadAttachmentRepository : CommonRepository<ThreadAttachment>
    {
        public ThreadAttachmentRepository(ApplicationDbContext context) : base(context) { }
        public async Task<List<ThreadAttachment>> GetThreadsByThreadId(int id)
        {
            Data.Entities.Thread.Thread thread = await context.Threads
                .Include(e => e.Attachments)
                .FirstAsync(p => p.Id == id);
            return thread.Attachments;
        }
        /*public void AddAttachment(ThreadAttachmentModel model)
        {
            ThreadAttachment attachment = new ThreadAttachment()
            {
                ThreadId = model.ThreadId,
                AttachmentUrl = model.AttachmentUrl
            };
            context.ThreadsAttachment.Add(attachment);
            context.SaveChanges();
        }

        public void Delete(ThreadAttachment model)
        {
            context.ThreadsAttachment.Remove(model);
            context.SaveChanges();
        }

        public IEnumerable<ThreadAttachmentModel> GetThreadAttachmentByThreadId(int id) => context.ThreadsAttachment.Where(c => c.ThreadId == id).Select(x => new ThreadAttachmentModel()
        {
            AttachmentUrl = x.AttachmentUrl
        }).ToList();*/
    }
}
