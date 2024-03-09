using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;

namespace AstralForum.ServiceModels
{
    public class CommentDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? ParentCommentId { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<ReactionDto> Reactions { get; set; } = new List<ReactionDto>();
        public List<CommentAttachmentDto> Attachments { get; set; } = new List<CommentAttachmentDto>();
    }
}
