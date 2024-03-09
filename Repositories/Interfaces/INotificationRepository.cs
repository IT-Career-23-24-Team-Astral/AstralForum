using AstralForum.Data.Entities;
using AstralForum.Models.Notification;

namespace AstralForum.Repositories.Interfaces
{
    public interface INotificationRepository
    {

        public Task<List<Notification>> GetNotificationsByThreadId(int id);
        public Task<List<Notification>> GetNotificationsByCommentId(int id);
        public Task<List<Notification>> GetNotificationsByTagId(int id);
        public Task<List<Notification>> GetNotificationsByReactionId(int id);
        public Task<List<Notification>> GetNotificationsByNotificationId(int id);
        /*void CreateNotification(NotificationModel model, User Id);
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        public IEnumerable<NotificationModel> GetNotificationsByNotificationId(int id);
        void ReadNotification(int notificationId, string userId);*/
    }
}