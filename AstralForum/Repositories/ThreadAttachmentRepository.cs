using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class ThreadAttachmentRepository : CommonRepository<ThreadAttachment>
    {
        private readonly ApplicationDbContext context;
        public ThreadAttachmentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void AddAttachment(ThreadAttachmentModel model)
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
        }).ToList();
    }
}
