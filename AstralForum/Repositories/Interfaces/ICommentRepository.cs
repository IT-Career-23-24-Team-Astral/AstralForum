using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models.Comment;

namespace AstralForum.Repositories.Interfaces
{
    public interface ICommentRepository : ICommonRepository<Comment>
    {
        public IEnumerable<CommentViewModel> GetComments(int id);
        public void AddComment(CommentViewModel model, string ownerName);
        public void Edit(Comment comment, CommentViewModel model);
        public void Delete(Comment comment);
    }
}
