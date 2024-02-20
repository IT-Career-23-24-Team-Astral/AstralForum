using AstralForum.Data.Entities;
using AstralForum.Models.Notification;

namespace AstralForum.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        void CreateNotification(NotificationModel model, User Id);
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        public IEnumerable<NotificationModel> GetNotificationsByNotificationId(int id);
        void ReadNotification(int notificationId, string userId);
    }
}