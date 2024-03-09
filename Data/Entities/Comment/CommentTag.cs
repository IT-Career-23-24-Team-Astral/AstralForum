namespace AstralForum.Data.Entities.Comment
{
    public class CommentTag : BaseEntity
    {
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        public int TagId { get; set; }
    }
}
