using System.ComponentModel.DataAnnotations;

namespace AstralForum.Data.Entities
{
    public class Notification : MetadataBaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public int NotificationId { get; set; }
    }
}
