namespace AstralForum.ServiceModels
{
    public class ThreadDto : MetaBaseEntityDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int ThreadCategory { get; set; }
    }
}
