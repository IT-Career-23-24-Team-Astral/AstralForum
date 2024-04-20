using AstralForum.ServiceModels;

namespace AstralForum.Models.Comment
{
    public class CommentTableViewModel
    {
		public int Id { get; set; }
		public string Text { get; set; }
		public UserDto Author { get; set; }
		public DateTime DateOfCreation { get; set; }
		public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
		public List<CommentReactionDto> Reactions { get; set; } = new List<CommentReactionDto>();
		public List<CommentAttachmentDto> Attachments { get; set; } = new List<CommentAttachmentDto>();
	}
}