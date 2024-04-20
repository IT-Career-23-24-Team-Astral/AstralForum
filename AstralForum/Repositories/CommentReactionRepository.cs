using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class CommentReactionRepository : CommonRepository<CommentReaction>
    {
        public CommentReactionRepository(ApplicationDbContext context) : base(context) { }
    }
}