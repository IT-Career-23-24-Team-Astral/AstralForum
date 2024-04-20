using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Reaction
{
	public interface IReactionService
	{
		Task<CommentReactionDto> AddCommentReaction(CommentReactionDto commentReactionDto, User createdBy);
		Task<CommentReactionDto> RemoveCommentReaction(CommentReactionDto commentReactionDto, User createdBy);
		Task<ThreadReactionDto> AddThreadReaction(ThreadReactionDto threadReactionDto, User createdBy);
		Task<ThreadReactionDto> RemoveThreadReaction(ThreadReactionDto threadReactionDto, User createdBy);
		Task<List<ReactionTypeDto>> GetAllReactionTypes();
		Task<ReactionTypeDto> AddReactionType(ReactionTypeDto reactionTypeDto);
		Task<ReactionTypeDto> DeleteReactionTypeById(int id);
	}
}
