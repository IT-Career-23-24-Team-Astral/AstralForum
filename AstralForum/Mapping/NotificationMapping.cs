using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class NotificationMapping
    {
        public static Notification ToEntity(this NotificationDto notificationDto)
        {
            Notification notification = new Notification();

            notification.Id = notificationDto.Id;
            notification.UserId = notificationDto.UserId;
            notification.NotificationId = notificationDto.NotificationId;
            notification.Text = notificationDto.Text;
            notification.NotificationType = notificationDto.NotificationType;
            notification.IsRead = notificationDto.IsRead;
            notification.CreatedOn = notificationDto.CreatedOn;

            return notification;

        }
        public static NotificationDto ToDto(this Notification notification)
        {
            NotificationDto notificationDto = new NotificationDto();

            notificationDto.Id = notification.Id;
            notificationDto.UserId = notification.UserId;
            notificationDto.NotificationId = notification.NotificationId;
            notificationDto.Text = notification.Text;
            notificationDto.NotificationType = notification.NotificationType;
            notificationDto.IsRead = notification.IsRead;

            return notificationDto;

        }
    }
}