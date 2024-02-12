using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models;

namespace AstralForum.Repositories.Interfaces
{
    public interface ICommentAttachment
    {
        public IEnumerable<CommentAttachmentModel> GetCommentAttachmentByCommentId(int id);
        public void AddAttachment(CommentAttachmentModel model);
        public void Delete(CommentAttachment model);
    }
}
