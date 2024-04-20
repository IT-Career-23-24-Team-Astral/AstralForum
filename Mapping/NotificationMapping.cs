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
            notification.Text = notificationDto.Text;
            notification.IsRead = notificationDto.IsRead;
            notification.Date = notificationDto.Date;

            return notification;

        }
        public static NotificationDto ToDto(this Notification notification)
        {
            NotificationDto notificationDto = new NotificationDto();

            notificationDto.Id = notification.Id;
            notificationDto.UserId = notification.UserId;
            notificationDto.User = notification.User.ToDto();
            notificationDto.Text = notification.Text;
            notificationDto.IsRead = notification.IsRead;
            notificationDto.Date = notification.Date;

            return notificationDto;

        }
    }
}