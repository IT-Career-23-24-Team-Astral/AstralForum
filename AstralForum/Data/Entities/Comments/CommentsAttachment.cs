using System.Net.Mail;

namespace AstralForum.Data.Entities.Comments
{
    public class CommentsAttachment
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public string AttachmentUrl { get; set; } 
    }
}
