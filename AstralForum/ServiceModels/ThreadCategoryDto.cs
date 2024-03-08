namespace AstralForum.ServiceModels
{
    public class ThreadCategoryDto : MetaBaseEntityDto
    {
        public string CategoryName { get; set; }
        public List<ThreadDto> Threads { get; set; }
    }
}
