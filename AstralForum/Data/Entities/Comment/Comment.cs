namespace AstralForum.Data.Entities.Comment
{
    public class Comment : MetadataBaseEntity
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
    }
}
