namespace AstralForum.ServiceModels
{
	public class ThreadCategoryDto : MetaBaseEntityDto
	{
	public ThreadCategoryDto() { Threads = new List<ThreadDto>(); }

		public string? ImageUrl { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public List<ThreadDto> Threads { get; set; }
	}
}
