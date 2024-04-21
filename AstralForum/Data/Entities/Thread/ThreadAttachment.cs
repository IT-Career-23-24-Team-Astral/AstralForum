namespace AstralForum.Data.Entities.Thread
{
    public class ThreadAttachment : BaseEntity
    {
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
        public string AttachmentUrl { get; set; }
        public string FileName { get; internal set; }
    }
}
