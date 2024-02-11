namespace AstralForum.Data.Entities._Notifications
{
    public class NotiComment : MetadataBaseEntity
    {
        public int NotificationId { get; set; }
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
