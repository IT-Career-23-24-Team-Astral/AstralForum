using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Reaction
{
	public interface IReactionFacade
	{
		int AddReactionToComment(int commentId, int reactionTypeId, User createdBy);
	}
}
