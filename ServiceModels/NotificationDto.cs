using AstralForum.Data.Enums;

namespace AstralForum.ServiceModels
{
    public class NotificationDto : MetaBaseEntityDto
    {
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
    }
}

