namespace AstralForum.ServiceModels
{
    public class CommentAttachmentDto : MetaBaseEntityDto
    {
        public int CommentId { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
