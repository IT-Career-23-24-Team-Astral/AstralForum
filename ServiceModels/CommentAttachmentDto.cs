using AstralForum.Data.Entities.Comment;

namespace AstralForum.ServiceModels
{
    public class CommentAttachmentDto : MetaBaseEntityDto
    {
        public int CommentId { get; set; }
        public string AttachmentUrl { get; set; }
        public string FileName { get; set; }
    }
}
