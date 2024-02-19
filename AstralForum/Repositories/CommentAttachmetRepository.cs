using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class CommentAttachmetRepository : CommonRepository<CommentAttachment>
    {
        public CommentAttachmetRepository(ApplicationDbContext context) : base(context) { }
        public async Task<List<CommentAttachment>> GetAttachmetsByCommentId(int id)
        {
            Comment comment = await context.Comments
                .Include(e => e.Attachments)
                .FirstAsync(p => p.Id == id); //или CommentId
            return comment.Attachments;
        }
       /* public void AddAttachment(CommentAttachmentModel model)
        {
            CommentAttachment comentAttachment = new CommentAttachment()
            {
                CommentId = model.CommentId,
                AttachmentUrl = model.AttachmentUrl
            };
            context.CommentsAttachment.Add(comentAttachment);
            context.SaveChanges();
        }

        public void Delete(CommentAttachment model)
        {
            context.CommentsAttachment.Remove(model);
            context.SaveChanges();
        }

        public IEnumerable<CommentAttachmentModel> GetCommentAttachmentByCommentId(int id) => context.CommentsAttachment.Where(c => c.CommentId == id).Select(x => new CommentAttachmentModel()
        {
            AttachmentUrl=x.AttachmentUrl
        }).ToList();*/
    }
}
