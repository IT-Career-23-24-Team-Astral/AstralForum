namespace AstralForum.ServiceModels
{
    public class CommentTagDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        public int TagId { get; set; }
    }
}