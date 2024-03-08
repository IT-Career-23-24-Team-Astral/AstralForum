using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
	public class ReactionDto : MetaBaseEntityDto
	{
		public int ThreadId { get; set; }
		public int CommentId { get; set; }
		public int ReactionTypeId { get; set; }
		public ReactionType ReactionType { get; set; }
	}
}