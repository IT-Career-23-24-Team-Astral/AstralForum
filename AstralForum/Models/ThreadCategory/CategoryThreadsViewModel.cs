using AstralForum.ServiceModels;

namespace AstralForum.Models.Thread
{
	public class CategoryThreadsViewModel
	{
		public string CategoryName { get; set; }
		public int CategoryId { get; set; }
		public IEnumerable<ThreadTableViewModel> Threads { get; set; }
	}
}