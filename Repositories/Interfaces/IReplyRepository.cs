using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Reply;
using AstralForum.Models;

namespace AstralForum.Repositories.Interfaces
{
    public interface IReplyRepository
    {
        public IEnumerable<ReplyModel> GetRepliesByReplyId(int id);
        public IEnumerable<ReplyModel> GetRepliesByCommentId(int id);
        public IEnumerable<ReplyModel> GetRepliesByThreadId(int id);
        public void AddReply(ReplyModel model, User id);
        public void Edit(Reply reply, ReplyModel model);
        public void Delete(Reply reply);
    }
}