using AstralForum.Data.Entities.Comment;

namespace AstralForum.ServiceModels
{
    public class CommentAttachmentDto : MetaBaseEntityDto
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
