using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models;
using AstralForum.Models.Notification;
using AstralForum.Repositories;
using AstralForum.Repository.Interfaces;
using AstralForum.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace AstralForum.Repository
{
    public class NotificationRepository : CommonRepository<Notification>, INotificationRepository
    {
        private ApplicationDbContext context;

        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void CreateNotification(NotificationModel model, User Id )
        {
            Notification notification = new Notification()
            {
                Id = model.Id,
                NotificationId = model.NotificationId,
                Message = model.Message,

            };
            context.Notifications.Add(notification);
            context.SaveChanges();
            var userNotification = new NotificationApplicationUser();
            userNotification.NotificationId = notification.Id;

            context.UserNotifications.Add(userNotification);
            context.SaveChanges();
        }
            public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            return context.UserNotifications.Where(u => u.UserId.Equals(userId) && !u.IsRead)
                                            .Include(n => n.Notification)
                                            .ToList();
        }
        public IEnumerable<NotificationModel> GetNotificationsByNotificationId(int id) => context.Notifications.Where(c => c.NotificationId == id).Select(a => new NotificationModel()
        {
            Id = a.Id,
            Date = DateTime.Now,
            Message = a.Message,
            NotificationId = a.NotificationId
        }).ToList();

        public void ReadNotification(int notificationId, string userId)
        {
            var notification = context.UserNotifications
                                        .FirstOrDefault(n => n.UserId.Equals(userId)
                                        && n.NotificationId == notificationId);
            notification.IsRead = true;
            context.UserNotifications.Update(notification);
            context.SaveChanges();
        }
    }
}