using AstralForum.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Data.Entities
{
    public class Notification : MetadataBaseEntity
    {
        [Required]
        public int UserId { get; set; }

        public int NotificationId { get; set; }
        [Required]
        public string Text { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
