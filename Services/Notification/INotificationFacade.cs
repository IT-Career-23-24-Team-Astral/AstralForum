using AstralForum.Data.Entities;
using AstralForum.Models.Notification;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Notification
{
	public interface INotificationFacade
	{
        //public Task<NotificationDto> CreateNotification(NotificationCreateViewModel notificationCreateFrom, int userId);
        public Task<NotificationModel> GetUserNotifications(int userId);
        public Task<NotificationModel> GetUserReadNotifications(int userId);
        public Task<NotificationDto> DeleteNotification(GetUserNotificationViewModel notificationForm, User user);

    }
}
