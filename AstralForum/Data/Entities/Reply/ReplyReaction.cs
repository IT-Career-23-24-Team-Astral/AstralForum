using AstralForum.Data.Entities.Reaction;

namespace AstralForum.Data.Entities.Reply
{
    public class ReplyReaction : MetadataBaseEntity
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        public string CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
