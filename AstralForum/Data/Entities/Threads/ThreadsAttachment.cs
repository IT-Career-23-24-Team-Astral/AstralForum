using System.Net.Mail;

namespace AstralForum.Data.Entities.Threads
{
    public class ThreadsAttachment
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string AttachmentUrl { get; set; } 
    }
}
