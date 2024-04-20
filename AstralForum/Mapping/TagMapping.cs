using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Tag;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class TagMapping
    {
        public static Tag ToEntity(this TagDto tagDto)
        {
            Tag tag = new Tag();

            tag.Id = tagDto.Id;
            tag.UserId = tagDto.UserId;
            tag.ThreadId = tagDto.ThreadId;
            tag.CommentId = tagDto.CommentId;
            tag.TagType = tagDto.TagType;
			tag.Tags = tagDto.Tags.Select(c => c.ToEntity()).ToList();

			return tag;
        }
        public static TagDto ToDto(this Tag tag, bool includeTags = true)

		{
            TagDto tagDto = new TagDto();

            tagDto.Id = tag.Id;
            tagDto.UserId = tag.UserId;
            tagDto.ThreadId = tag.ThreadId;
            tagDto.CommentId = tag.CommentId;
            tagDto.TagType = tag.TagType;
			tagDto.Tags = includeTags ? tag.Tags.Select(c => c.ToDto()).ToList() : new List<TagDto>();

			return tagDto;
        }
    }
}
