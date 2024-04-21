using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
	public static class ThreadReactionMapping
	{
		public static ThreadReaction ToEntity(this ThreadReactionDto threadReactionDto)
		{
			ThreadReaction threadReaction = new ThreadReaction();

			threadReaction.Id = threadReactionDto.Id;
			threadReaction.ThreadId = threadReactionDto.ThreadId;
			threadReaction.Thread = threadReactionDto.Thread?.ToEntity();
			threadReaction.ReactionTypeId = threadReactionDto.ReactionTypeId;
			threadReaction.ReactionType = threadReactionDto.ReactionTypeDto?.ToEntity();
			threadReaction.CreatedById = threadReactionDto.CreatedById;
			threadReaction.CreatedBy = threadReactionDto.CreatedBy?.ToEntity();
			threadReaction.CreatedOn = threadReactionDto.CreatedOn;
			
			return threadReaction;
		}
		public static ThreadReactionDto ToDto(this ThreadReaction threadReaction)
		{
			ThreadReactionDto threadReactionDto = new ThreadReactionDto();

			threadReactionDto.Id = threadReaction.Id;
			threadReactionDto.ThreadId = threadReaction.ThreadId;
			threadReactionDto.Thread = threadReaction.Thread?.ToDto(false, false, false, false, false, false, false);
			threadReactionDto.ReactionTypeId = threadReaction.ReactionTypeId;
			threadReactionDto.ReactionTypeDto = threadReaction.ReactionType?.ToDto(false);
			threadReactionDto.CreatedById = threadReaction.CreatedById;
			threadReactionDto.CreatedBy = threadReaction.CreatedBy?.ToDto();
			threadReactionDto.CreatedOn = threadReaction.CreatedOn;

			return threadReactionDto;
		}
	}
}
