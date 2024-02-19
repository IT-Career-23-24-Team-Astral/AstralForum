using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class ReactionMapping
    {
        public static Reaction ToEntity(this ReactionDto reactionDto)
        {
            Reaction reaction = new Reaction();

            reaction.Id = reactionDto.Id;
            reaction.ThreadsId = reactionDto.ThreadId;
            reaction.CommentId = reactionDto.CommentId;
            reaction.ReactionTypeId = reactionDto.ReactionTypeId;
            reaction.ReactionType = reactionDto.ReactionType;
            reaction.CreatedById = reactionDto.CreatedById;
            reaction.CreatedOn = reactionDto.CreatedOn;
            
            return reaction;
        }
        public static ReactionDto ToDto(this Reaction reaction)
        {
            ReactionDto reactionDto = new ReactionDto();

            reactionDto.Id = reaction.Id;
            reactionDto.ThreadId = reaction.ThreadsId;
            reactionDto.CommentId = reaction.CommentId;
            reactionDto.ReactionTypeId = reaction.ReactionTypeId;
            reactionDto.ReactionType = reaction.ReactionType;
            reactionDto.CreatedById = reaction.CreatedById;
            reactionDto.CreatedOn = reaction.CreatedOn;

            return reactionDto;
        }
    }
}
