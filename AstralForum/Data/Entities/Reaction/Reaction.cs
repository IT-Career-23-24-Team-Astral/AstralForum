namespace AstralForum.Data.Entities.Reaction
{
    public class Reaction : MetadataBaseEntity
    {
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        public int ReactionId { get; set; }
    }
}
