using AstralForum.Data.Enums;


namespace AstralForum.ServiceModels
{
    public class NotificationDto : BaseEntityDto
    {
        public UserDto User { get; set; }
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
    }
}

