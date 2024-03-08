using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;

using AstralForum.Models.Comment;

namespace AstralForum.Repositories.Interfaces
{
    public interface ICommentRepository : ICommonRepository<Comment>
    {
        public IEnumerable<CommentViewModel> GetCommentsByThreadId(int id);
        public IEnumerable<CommentViewModel> GetCommentsByCommentId(int id);
        public void AddComment(CommentViewModel model, User id);
        public void Edit(Comment comment, CommentViewModel model);
        public void Delete(Comment comment);
    }
}
