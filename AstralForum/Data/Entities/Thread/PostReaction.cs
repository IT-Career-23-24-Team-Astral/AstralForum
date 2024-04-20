using AstralForum.Data.Entities.Reaction;

namespace AstralForum.Data.Entities.Thread
{
    public class PostReaction : BaseEntity
    {
        public ReactionType ReactionType { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}