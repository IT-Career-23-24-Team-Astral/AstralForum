using AstralForum.ServiceModels;

namespace AstralForum.Services.Reaction
{
	public interface IReactionService
	{
		Task<CommentReactionDto> AddCommentReaction(CommentReactionDto commentReactionDto);
	}
}
