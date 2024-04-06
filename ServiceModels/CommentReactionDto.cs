using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
	public class CommentReactionDto : ReactionBaseEntityDto
	{
		public CommentDto CommentDto { get; set; }
		public int CommentId { get; set; }
	}
}