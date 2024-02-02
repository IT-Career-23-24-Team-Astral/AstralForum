using System.Net.Mail;

namespace AstralForum.Data.Entities.Comment
{
    public class CommentAttachment : BaseEntity
    {
        public int CommentId { get; set; }
        public string AttachmentUrl { get; set; } 
    }
}
