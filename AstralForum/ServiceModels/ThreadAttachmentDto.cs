using AstralForum.Data.Entities;

namespace AstralForum.ServiceModels
{
    public class ThreadAttachmentDto : MetaBaseEntityDto
    {
        public int ThreadId { get; set; }
        public ThreadDto Thread { get; set; }
        public string AttachmentUrl { get; set; }
        public string FileName { get; set; }
    }
}
