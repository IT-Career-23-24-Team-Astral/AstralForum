using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Notification
{
    public class NotificationModel
    {
        public List<GetUserNotificationViewModel> UserNotifications { get; set; }
    }
}