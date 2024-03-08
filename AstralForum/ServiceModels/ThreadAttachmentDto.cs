using AstralForum.Data.Entities;

namespace AstralForum.ServiceModels
{
    public class ThreadAttachmentDto : BaseEntityDto
    {
        public int ThreadId { get; set; }
        public ThreadDto Thread { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
