using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
	public class ReactionBaseEntityDto : MetaBaseEntityDto
	{
		public int ReactionTypeId { get; set; }
		public ReactionTypeDto ReactionTypeDto { get; set; }
	}
}
