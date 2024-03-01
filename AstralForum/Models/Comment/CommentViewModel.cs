using AstralForum.ServiceModels;

namespace AstralForum.Models.Comment
{
	public class CommentViewModel
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public UserDto Author { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool HasReplies { get; set; }
	}
}
