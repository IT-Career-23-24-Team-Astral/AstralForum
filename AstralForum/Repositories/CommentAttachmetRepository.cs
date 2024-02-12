using AstralForum.Data.Entities.Comment;
using AstralForum.Models;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class CommentAttachmetRepository : ICommentAttachment
    {
        private readonly ApplicationDbContext context;
        public CommentAttachmetRepository(ApplicationDbContext context) 
        {
            this.context = context; 
        }
        public void AddAttachment(CommentAttachmentModel model)
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
        }).ToList();
    }
}
