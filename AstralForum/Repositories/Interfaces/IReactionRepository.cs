using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Models;

namespace AstralForum.Repositories.Interfaces
{
    public interface IReactionRepository : ICommonRepository<Reaction>
    {
        public IEnumerable<ReactionModel> GetReactionsByThreadId(int id);
        public IEnumerable<ReactionModel> GetReactionsByCommentId(int id);
        public void AddReaction(ReactionModel model, User id);
        public void Delete(Reaction model);
    }
}
