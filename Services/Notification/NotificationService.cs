using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AstralForum.Services.Notification
{
	public class NotificationService : INotificationService
	{
		private readonly NotificationRepository _notificationRepository;
		public NotificationService(NotificationRepository notificationRepository) 
		{
			_notificationRepository = notificationRepository;
		}
        public async Task<NotificationDto> CreateNotification(NotificationDto notificationDto, int userId)
        {
            Data.Entities.Notification notification = notificationDto.ToEntity();
            notification.UserId = userId;
            var createdNotification = await _notificationRepository.Create(notification);
            return createdNotification.ToDto();
        }

        public async Task<List<NotificationDto>> GetUserNotifications(int userId)
        {
            var notifications = await _notificationRepository.GetUserNotifications(userId);
            return notifications.Select(n => n.ToDto()).ToList();
        }

        public async Task<NotificationDto> ReadNotification(int notificationId, User user)
		{
            var notifications = await _notificationRepository.ReadNotification(notificationId, user.Id);
			return notifications.ToDto();
        }


    }
}
