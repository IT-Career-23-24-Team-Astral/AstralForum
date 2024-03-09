using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.ServiceModels;

namespace AstralForum.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationRepository _notificationRepository;

        public NotificationService(NotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task<NotificationDto> AddNotification(NotificationDto notificationDto)
        {
            Notification notification = notificationDto.ToEntity();

            return (await _notificationRepository.Create(notification)).ToDto();
        }

        /*public async Task<List<NotificationDto>> GetAllNotificationsByThreadId(int id)
        {
            List<Notification> notifications = await _notificationRepository.GetNotificationsByThreadId(id);
            List<NotificationDto> notificationDto = notifications.Select(notification => notification.ToDto()).ToList();

            return notificationDto;
        }*/

        public async Task<List<NotificationDto>> GetAllNotificationsByCommentId(int id)
        {
            List<Notification> notifications = await _notificationRepository.GetNotificationsByCommentId(id);
            List<NotificationDto> notificationDto = notifications.Select(notification => notification.ToDto()).ToList();

            return notificationDto;
        }
        public async Task<List<NotificationDto>> GetAllNotificationsByTagId(int id)
        {
            List<Notification> notifications = await _notificationRepository.GetNotificationsByTagId(id);
            List<NotificationDto> notificationDto = notifications.Select(notification => notification.ToDto()).ToList();

            return notificationDto;
        }
        /*public async Task<List<NotificationDto>> GetAllNotificationsByReactionId(int id)
        {
            List<Notification> notifications = await _notificationRepository.GetNotificationsByReactionId(id);
            List<NotificationDto> notificationDto = notifications.Select(notification => notification.ToDto()).ToList();

            return notificationDto;
        }*/
        public async Task<List<NotificationDto>> GetAllNotificationsByNotificationId(int id)
        {
            List<Notification> notifications = await _notificationRepository.GetNotificationsByNotificationId(id);
            List<NotificationDto> notificationDto = notifications.Select(notification => notification.ToDto()).ToList();

            return notificationDto;
        }

    }
}
