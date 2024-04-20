namespace AstralForum.Models.Thread
{
	public class CategoryThreadsViewModel
	{
		public string CategoryName { get; set; }
		public string Description { get; set; }// redundant
		public int CategoryId { get; set; }
		public IEnumerable<ThreadTableViewModel> Threads { get; set; }
	}
}
