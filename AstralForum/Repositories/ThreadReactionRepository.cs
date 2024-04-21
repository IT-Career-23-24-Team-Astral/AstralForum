using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Models;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class ThreadReactionRepository : CommonRepository<ThreadReaction>
    {
        public ThreadReactionRepository(ApplicationDbContext context) : base(context) { }
    }
}