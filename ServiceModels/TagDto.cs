using AstralForum.Data.Entities.Tag;
using System.Diagnostics;

namespace AstralForum.ServiceModels
{
    public class TagDto : BaseEntityDto
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }

        public int ThreadId { get; set; }
        public TagType TagType { get; set; }
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
