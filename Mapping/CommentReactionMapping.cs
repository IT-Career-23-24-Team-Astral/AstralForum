using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
	public static class CommentReactionMapping
	{
		public static CommentReaction ToEntity(this CommentReactionDto commentReactionDto)
		{
			CommentReaction commentReaction = new CommentReaction();

			commentReaction.Id = commentReactionDto.Id;
			commentReaction.CommentId = commentReactionDto.CommentId;
			commentReaction.Comment = commentReactionDto.CommentDto?.ToEntity();
			commentReaction.ReactionTypeId = commentReactionDto.ReactionTypeId;
			commentReaction.ReactionType = commentReactionDto.ReactionTypeDto?.ToEntity();
			commentReaction.CreatedById = commentReactionDto.CreatedById;
			commentReaction.CreatedOn = commentReactionDto.CreatedOn;

			return commentReaction;
		}
		public static CommentReactionDto ToDto(this CommentReaction reaction)
		{
			CommentReactionDto commentReactionDto = new CommentReactionDto();

			commentReactionDto.Id = reaction.Id;
			commentReactionDto.CommentId = reaction.CommentId;
			commentReactionDto.CommentDto = reaction.Comment?.ToDto(false, false, false);
			commentReactionDto.ReactionTypeId = reaction.ReactionTypeId;
			commentReactionDto.ReactionTypeDto = reaction.ReactionType?.ToDto(false);
			commentReactionDto.CreatedById = reaction.CreatedById;
			commentReactionDto.CreatedBy = reaction.CreatedBy?.ToDto();
			commentReactionDto.CreatedOn = reaction.CreatedOn;

			return commentReactionDto;
		}
	}
}
