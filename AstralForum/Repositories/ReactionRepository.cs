using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Models;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class ReactionRepository : CommonRepository<Reaction>//, IReactionRepository
    {
        private readonly ApplicationDbContext context;
        public ReactionRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        /*public void AddReaction(ReactionModel model, User id)
        {
            Reaction reaction = new Reaction()
            {
                ThreadId = model.ThreadId,
                CommentId = model.CommentId,
                ReactionId = model.ReactionId,
                CreatedById = id.Id,
            };
            context.Reactions.Add(reaction);
            context.SaveChanges();
        }

        public void Delete(Reaction model)
        {
            context.Reactions.Remove(model);
            context.SaveChanges();
        }

        public IEnumerable<ReactionModel> GetReactionsByCommentId(int id) => context.Comments.Where(c => c.CommentId == id).Select(x => new ReactionModel()
        {
            ReactionId = x.Id,
        }).ToList();

        public IEnumerable<ReactionModel> GetReactionsByThreadId(int id) => context.Threads.Where(c => c.Id == id).Select(x => new ReactionModel()
        {
            ReactionId = x.Id,
        }).ToList();*/
    }
}
