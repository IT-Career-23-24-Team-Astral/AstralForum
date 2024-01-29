namespace AstralForum.Data.Entities.Reactions
{
    public class Reactions
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ReactionId { get; set; }
    }
}
