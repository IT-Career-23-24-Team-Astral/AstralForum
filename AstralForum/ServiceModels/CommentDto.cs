using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
    public class CommentDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ReactionDto> Reactions { get; set; }
        public List<CommentAttachmentDto> Attachments { get; set; }
    }
}
