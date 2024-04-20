using Microsoft.EntityFrameworkCore;

namespace AstralForum.Data.Entities.Reaction
{
    public class ThreadReaction : ReactionBaseEntity
    {
        public int ThreadId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Thread.Thread Thread { get; set; }
    }
}