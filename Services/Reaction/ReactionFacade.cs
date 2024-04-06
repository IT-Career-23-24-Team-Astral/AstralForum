using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;

namespace AstralForum.Services.Reaction
{
	public class ReactionFacade : IReactionFacade
	{
		private readonly IReactionService _reactionService;
		private readonly ICommentService _commentService;

		public ReactionFacade(IReactionService reactionService, ICommentService commentService)
		{
			_reactionService = reactionService;
			_commentService = commentService;
		}

		public int AddReactionToComment(int commentId, int reactionTypeId, User createdBy)
		{
			CommentReactionDto reactionDto = new CommentReactionDto()
			{
				CommentId = commentId,
				ReactionTypeId = reactionTypeId,
				CreatedBy = createdBy.ToDto(),
				CreatedById = createdBy.Id
			};

			_reactionService.AddCommentReaction(reactionDto);

			CommentDto updatedComment = _commentService.GetCommentByCommentId(commentId);

			return updatedComment.Reactions.Select(r => r.ReactionTypeId == reactionTypeId).Count();
		}
	}
}
