using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
	public class ThreadReactionDto : ReactionBaseEntityDto
	{
		public ThreadDto Thread { get; set; }
		public int ThreadId { get; set; }
	}
}