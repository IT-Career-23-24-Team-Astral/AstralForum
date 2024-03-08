namespace AstralForum.ServiceModels
{
    public class PostTagDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        //public int PostId { get; set; }
        public int TagId { get; set; }
    }
}