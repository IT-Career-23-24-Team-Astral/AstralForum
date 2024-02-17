using AstralForum.Data.Entities.Reaction;

namespace AstralForum.Data.Entities.Thread
{
    public class PostReaction : MetadataBaseEntity
    {
        public ReactionType ReactionType { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
