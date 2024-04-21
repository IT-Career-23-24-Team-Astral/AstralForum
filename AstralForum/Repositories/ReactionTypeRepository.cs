using AstralForum.Data.Entities.Reaction;

namespace AstralForum.Repositories
{
	public class ReactionTypeRepository : CommonRepository<ReactionType>
	{
		public ReactionTypeRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
