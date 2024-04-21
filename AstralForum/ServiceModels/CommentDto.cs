using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using System.Collections.Generic;

namespace AstralForum.ServiceModels
{
    public class CommentDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? ParentCommentId { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<CommentReactionDto> Reactions { get; set; } = new List<CommentReactionDto>();
        public List<CommentAttachmentDto> Attachments { get; set; } = new List<CommentAttachmentDto>();
    }
}
