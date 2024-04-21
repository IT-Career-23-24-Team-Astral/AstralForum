
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Data.Entities
{
    public class Notification : BaseEntity
    {
        [Required]
        public User User { get; set; }
        public int UserId { get; set; }

        [Required]
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}