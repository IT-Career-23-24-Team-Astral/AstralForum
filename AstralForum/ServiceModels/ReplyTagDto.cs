namespace AstralForum.ServiceModels
{
    public class ReplyTagDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public int ReplyId { get; set; }
        public int TagId { get; set; }
    }
}