﻿using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Categories;
using AstralForum.Models.Notification;
using AstralForum.Models.ThreadCategory;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services.ThreadCategory;

namespace AstralForum.Services.Notification
{
    public class NotificationFacade : INotificationFacade
    {
        private readonly INotificationService _notificationService;
        public NotificationFacade(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        /*public async Task<NotificationDto> CreateNotification(NotificationCreateViewModel notificationCreateFrom, int userId)
		{

			NotificationDto notification = new NotificationDto()
			{

				Text = notificationCreateFrom.Text,
				Id = notificationCreateFrom.NotificationId,
				IsRead = notificationCreateFrom.IsRead,
				UserV = user.ToDto(),
				UserId = user.Id
				
			
				
			};

			return await _notificationService.CreateNotification(notification, userId);
		}*/
        public async Task<NotificationModel> GetUserNotifications(int userId)
        {
            List<NotificationDto> notifications = await _notificationService.GetUserNotifications(userId);

            List<GetUserNotificationViewModel> models = notifications.Select(notification => new GetUserNotificationViewModel
            {
                NotificationId = notification.Id,
                UserId = notification.User.Id,
                User = notification.User,
                IsRead = notification.IsRead,
                Text = notification.Text,
                Date = notification.Date
            }).ToList();

            return new NotificationModel
            {
                UserNotifications = models
            };
        }
        public async Task<NotificationModel> GetUserReadNotifications(int userId)
        {
            List<NotificationDto> notifications = await _notificationService.GetUserReadNotifications(userId);

            List<GetUserNotificationViewModel> models = notifications.Select(notification => new GetUserNotificationViewModel
            {
                NotificationId = notification.Id,
                UserId = notification.User.Id,
                User = notification.User,
                IsRead = notification.IsRead,
                Text = notification.Text,
                Date = notification.Date
            }).ToList();

            return new NotificationModel
            {
                UserNotifications = models
            };
        }
        public async Task<NotificationDto> DeleteNotification(GetUserNotificationViewModel notificationForm, User user)
        {

            NotificationDto notificationDto = new NotificationDto()
            {
                Id = notificationForm.NotificationId,
                UserId = user.Id,
                User = user.ToDto(),
                IsRead = notificationForm.IsRead,
                Text = notificationForm.Text,
                Date = notificationForm.Date
            };

            return await _notificationService.DeleteNotification(notificationDto, user);
        }
    }
}

