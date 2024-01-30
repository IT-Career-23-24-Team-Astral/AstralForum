using System.Net.Mail;

namespace AstralForum.Data.Entities.Comment
{
    public class CommentAttachment : MetadataBaseEntity
    {
        // Защо тук да има наследяване като от коментара може да се види тази информация? Може примерно когато edit-ва да се гледа.
        public int CommentId { get; set; }
        public string AttachmentUrl { get; set; } 
    }
}
