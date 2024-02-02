using System.Net.Mail;

namespace AstralForum.Data.Entities.Thread
{
    public class ThreadAttachment : BaseEntity
    {
        public int ThreadId { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
