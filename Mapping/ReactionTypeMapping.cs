using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class ReactionTypeMapping
    {
        public static ReactionType ToEntity(this ReactionTypeDto reactionTypeDto)
        {
            ReactionType reactionType = new ReactionType();

            reactionType.Id = reactionTypeDto.Id;
			reactionType.Name = reactionTypeDto.Name;
			reactionType.ImageUrl = reactionTypeDto.ImageUrl;
            reactionType.CreatedById = reactionTypeDto.CreatedById;
            reactionType.CreatedBy = reactionTypeDto.CreatedBy.ToEntity();
            reactionType.CreatedOn = reactionTypeDto.CreatedOn;

            return reactionType;
        }
        public static ReactionTypeDto ToDto(this ReactionType reactionType)
        {
            ReactionTypeDto reactionTypeDto = new ReactionTypeDto();

            reactionTypeDto.Id = reactionType.Id;
            reactionTypeDto.Name = reactionType.Name;
            reactionTypeDto.ImageUrl = reactionType.ImageUrl;
            reactionTypeDto.CreatedById = reactionType.CreatedById;
            reactionTypeDto.CreatedBy = reactionType.CreatedBy.ToDto();
            reactionTypeDto.CreatedOn = reactionType.CreatedOn;

            return reactionTypeDto;
        }
    }
}