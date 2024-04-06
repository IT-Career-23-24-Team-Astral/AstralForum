using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class CommentReactionRepository : CommonRepository<CommentReaction>
    {
        public CommentReactionRepository(ApplicationDbContext context) : base(context) { }
        public async Task<List<CommentReaction>> GetReactionsByThreadId(int id)
        {
            Data.Entities.Thread.Thread thread = await context.Threads
                .Include(e => e.Reactions)
                .FirstAsync(p => p.Id == id);
            return thread.Reactions;
        }
        public async Task<List<CommentReaction>> GetReactionsByCommentId(int id)
        {
            Comment comment = await context.Comments
                .Include(e => e.Reactions)
                .FirstAsync(p => p.Id == id);
            return comment.Reactions;
        }
        /*public void AddReaction(ReactionModel model, User id)
        {
            Reaction reaction = new Reaction()
            {
                ThreadId = model.ThreadId,
                ParentCommentId = model.ParentCommentId,
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

        public IEnumerable<ReactionModel> GetReactionsByCommentId(int id) => context.Comments.Where(c => c.ParentCommentId == id).Select(x => new ReactionModel()
        {
            ReactionId = x.Id,
        }).ToList();

        public IEnumerable<ReactionModel> GetReactionsByThreadId(int id) => context.Threads.Where(c => c.Id == id).Select(x => new ReactionModel()
        {
            ReactionId = x.Id,
        }).ToList();*/
    }
}