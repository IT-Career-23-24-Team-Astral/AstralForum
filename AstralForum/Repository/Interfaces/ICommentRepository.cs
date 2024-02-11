using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models;

namespace AstralForum.Repositories.Interfaces
{
    public interface ICommentRepository : ICommonRepository<Comment>
    {
        public IEnumerable<CommentModel> GetCommentsByThreadId(int id);
        public IEnumerable<CommentModel> GetCommentsByCommentId(int id);
        public void AddComment(CommentModel model, User id);
        public void Edit(Comment comment, CommentModel model);
        public void Delete(Comment comment);
    }
}