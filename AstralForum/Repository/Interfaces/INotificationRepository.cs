using AstralForum.Data.Entities;
using AstralForum.Models.Notification;

namespace AstralForum.Repository.Interfaces
{
    public interface INotificationRepository
    {
        void CreateNotification(NotificationModel model, User Id);
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void ReadNotification(int notificationId, string userId);
    }
}