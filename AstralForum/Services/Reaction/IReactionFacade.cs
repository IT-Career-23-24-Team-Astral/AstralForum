using AstralForum.Data.Entities;
using AstralForum.Models.Reaction;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Reaction
{
	public interface IReactionFacade
	{
		Task<ReactionTypeDto> AddReactionType(ReactionTypeCreationFormModel reactionTypeCreationForm, User createdBy);
		Task<int> AddReactionToComment(int commentId, int reactionTypeId, User createdBy);
		Task<int> RemoveCommentReaction(int id, int commentId, int reactionTypeId, User createdBy);
		Task<int> AddReactionToThread(int threadId, int reactionTypeId, User createdBy);
		Task<int> RemoveThreadReaction(int id, int threadId, int reactionTypeId, User createdBy);
	}
}
