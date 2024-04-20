using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Notification
{
	public interface INotificationService
	{
		public Task<NotificationDto> CreateNotification(NotificationDto notificationDto, int userId);
		public Task<List<NotificationDto>> GetUserNotifications(int userId);
		public Task<NotificationDto> ReadNotification(int notificationId, User user);

    }
}
