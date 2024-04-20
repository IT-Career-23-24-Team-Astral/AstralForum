using AstralForum.Data.Entities;
using AstralForum.Models.Notification;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Notification
{
	public interface INotificationFacade
	{
        //public Task<NotificationDto> CreateNotification(NotificationCreateViewModel notificationCreateFrom, int userId);
        public Task<NotificationModel> GetUserNotifications(int userId);

    }
}
