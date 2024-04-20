using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Services.Reaction
{
    public class ReactionService : IReactionService
    {
        private readonly CommentReactionRepository commentReactionRepository;
		private readonly ThreadReactionRepository threadReactionRepository;
        private readonly ReactionTypeRepository reactionTypeRepository;

        public ReactionService(CommentReactionRepository commentReactionRepository, ThreadReactionRepository threadReactionRepository, ReactionTypeRepository reactionTypeRepository)
		{
			this.commentReactionRepository = commentReactionRepository;
			this.threadReactionRepository = threadReactionRepository;
			this.reactionTypeRepository = reactionTypeRepository;
		}

		public async Task<CommentReactionDto> AddCommentReaction(CommentReactionDto commentReactionDto, User createdBy)
        {
            CommentReaction commentReaction = commentReactionDto.ToEntity();
            commentReaction.CreatedBy = createdBy;
            return (await commentReactionRepository.Create(commentReaction)).ToDto();
        }

		public async Task<CommentReactionDto> RemoveCommentReaction(CommentReactionDto commentReactionDto, User createdBy)
		{
			CommentReaction commentReaction = commentReactionDto.ToEntity();
			commentReaction.CreatedBy = createdBy;
			return (await commentReactionRepository.Delete(commentReaction)).ToDto();
		}

		public async Task<ThreadReactionDto> AddThreadReaction(ThreadReactionDto threadReactionDto, User createdBy)
		{
			ThreadReaction threadReaction = threadReactionDto.ToEntity();
			threadReaction.CreatedBy = createdBy;
			return (await threadReactionRepository.Create(threadReaction)).ToDto();
		}

		public async Task<ThreadReactionDto> RemoveThreadReaction(ThreadReactionDto threadReactionDto, User createdBy)
		{
			ThreadReaction threadReaction = threadReactionDto.ToEntity();
			threadReaction.CreatedBy = createdBy;
			return (await threadReactionRepository.Delete(threadReaction)).ToDto();
		}

		public async Task<List<ReactionTypeDto>> GetAllReactionTypes()
		{
			List<ReactionType> reactionTypes = await reactionTypeRepository
				.GetAll()
				.Include(rt => rt.CreatedBy)
				.ToListAsync();

			return reactionTypes.Select(rt => rt.ToDto()).ToList();
		}

		public async Task<ReactionTypeDto> AddReactionType(ReactionTypeDto reactionTypeDto)
		{
			ReactionType reactionType = reactionTypeDto.ToEntity();

			return (await reactionTypeRepository.Create(reactionType)).ToDto(false);
		}

		public async Task<ReactionTypeDto> DeleteReactionTypeById(int id)
		{
			ReactionType reactionTypeToDelete = await reactionTypeRepository.GetAllAsNoTracking().SingleOrDefaultAsync(rt => rt.Id == id);

			if (reactionTypeToDelete == default)
			{
				throw new ArgumentException("No reaction type with such id exists");
			}

			return (await reactionTypeRepository.Delete(reactionTypeToDelete)).ToDto(false);
		}
	}
}
