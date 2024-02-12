using System.ComponentModel.DataAnnotations;

namespace AstralForum.Data.Entities
{
    public class Notification : MetadataBaseEntity
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int NotificationId { get; set; }
    }
}
