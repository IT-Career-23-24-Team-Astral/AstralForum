using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Reaction;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;
using AstralForum.Services.Thread;

namespace AstralForum.Services.Reaction
{
	public class ReactionFacade : IReactionFacade
	{
		private readonly IReactionService _reactionService;
		private readonly ICommentService _commentService;
		private readonly IThreadService _threadService;
		private readonly ICloudinaryService _cloudinaryService;

		public ReactionFacade(IReactionService reactionService, ICommentService commentService, IThreadService threadService, ICloudinaryService cloudinaryService)
		{
			_reactionService = reactionService;
			_commentService = commentService;
			_threadService = threadService;
			_cloudinaryService = cloudinaryService;
		}

		public async Task<ReactionTypeDto> AddReactionType(ReactionTypeCreationFormModel reactionTypeCreationForm, User createdBy)
		{
			ReactionTypeDto reactionTypeCreationFormDto = new ReactionTypeDto()
			{
				Name = reactionTypeCreationForm.Name,
				ImageUrl = _cloudinaryService.UploadImage(reactionTypeCreationForm.Image).SecureUrl.AbsoluteUri,
				CreatedById = createdBy.Id
			};

			ReactionTypeDto reactionTypeDto = await _reactionService.AddReactionType(reactionTypeCreationFormDto);

			return reactionTypeDto;
		}

		public async Task<int> AddReactionToComment(int commentId, int reactionTypeId, User createdBy)
		{
			CommentReactionDto reactionDto = new CommentReactionDto()
			{
				CommentId = commentId,
				ReactionTypeId = reactionTypeId,
				CreatedBy = createdBy.ToDto(),
				CreatedById = createdBy.Id
			};

			CommentReactionDto commentReactionDto = await _reactionService.AddCommentReaction(reactionDto, createdBy);

			CommentDto updatedComment = _commentService.GetCommentByCommentIdWithReactions(commentId);

			return updatedComment.Reactions.Count(r => r.ReactionTypeId == reactionTypeId);
		}

		public async Task<int> AddReactionToThread(int threadId, int reactionTypeId, User createdBy)
		{
			ThreadReactionDto reactionDto = new ThreadReactionDto()
			{
				ThreadId = threadId,
				ReactionTypeId = reactionTypeId,
				CreatedBy = createdBy.ToDto(),
				CreatedById = createdBy.Id
			};

			ThreadReactionDto threadReactionDto = await _reactionService.AddThreadReaction(reactionDto, createdBy);

			ThreadDto updatedThread = _threadService.GetThreadByThreadIdWithReactions(threadId);

			return updatedThread.Reactions.Count(r => r.ReactionTypeId == reactionTypeId);
		}

		public async Task<int> RemoveCommentReaction(int id, int commentId, int reactionTypeId, User createdBy)
		{
			CommentReactionDto reactionDto = new CommentReactionDto()
			{
				Id = id,
				CommentId = commentId,
				ReactionTypeId = reactionTypeId,
				CreatedBy = createdBy.ToDto(),
				CreatedById = createdBy.Id
			};

			CommentReactionDto commentReactionDto = await _reactionService.RemoveCommentReaction(reactionDto, createdBy);

			CommentDto updatedComment = _commentService.GetCommentByCommentIdWithReactions(commentId);

			return updatedComment.Reactions.Count(r => r.ReactionTypeId == reactionTypeId);
		}

		public async Task<int> RemoveThreadReaction(int id, int threadId, int reactionTypeId, User createdBy)
		{
			ThreadReactionDto reactionDto = new ThreadReactionDto()
			{
				Id = id,
				ThreadId = threadId,
				ReactionTypeId = reactionTypeId,
				CreatedBy = createdBy.ToDto(),
				CreatedById = createdBy.Id
			};

			ThreadReactionDto threadReactionDto = await _reactionService.RemoveThreadReaction(reactionDto, createdBy);

			ThreadDto updatedThread = _threadService.GetThreadByThreadIdWithReactions(threadId);

			return updatedThread.Reactions.Count(r => r.ReactionTypeId == reactionTypeId);
		}
	}
}
