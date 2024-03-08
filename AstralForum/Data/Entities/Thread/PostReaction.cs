using AstralForum.Data.Entities.Reaction;

namespace AstralForum.Data.Entities.Thread
{
    public class PostReaction : BaseEntity
    {
        public ReactionType ReactionType { get; set; }

        public int PostId { get; set; }

        public Thread Post { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}