namespace AstralForum.ServiceModels
{
    public class CommentDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
    }
}
