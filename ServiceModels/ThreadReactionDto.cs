using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
	public class ThreadReactionDto : MetaBaseEntityDto
	{
		public int ThreadId { get; set; }
		public ThreadDto Thread { get; set; }
		public int ReactionTypeId { get; set; }
		public ReactionTypeDto ReactionType { get; set; }
	}
}