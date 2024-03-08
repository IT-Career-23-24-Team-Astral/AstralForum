using Microsoft.Build.Framework;

namespace AstralForum.Models.Thread
{
	public class ThreadCreationFormModel
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public IEnumerable<IFormFile> Attachments { get; set; }
	}
}