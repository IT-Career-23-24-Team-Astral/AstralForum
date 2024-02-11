using AstralForum.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities._Notifications
{
    public class NotiBan : Ban
    {
        public int NotificationId { get; set; }
        public string Reason { get; set; }
        public DateTime BanEnd { get; set; }

        public User AffectedUser { get; set; }
        public int AffectedUserId { get; set; }
    }
}
