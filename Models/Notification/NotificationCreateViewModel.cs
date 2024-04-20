using AstralForum.ServiceModels;
using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Notification
{
    public class NotificationCreateViewModel
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int NotificationId {  get; set; }
        public bool IsRead { get; set; }
        public UserDto UserV { get; set; }
        public int UserId { get; set; }
    }
}