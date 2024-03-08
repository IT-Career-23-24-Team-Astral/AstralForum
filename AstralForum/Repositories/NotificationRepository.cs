using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Tag;
using AstralForum.Models;
using AstralForum.Models.Notification;
using AstralForum.Repositories.Interfaces;
using AstralForum.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace AstralForum.Repositories
{
    public class NotificationRepository : CommonRepository<Notification>, INotificationRepository
    {
        private ApplicationDbContext context;

        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Notification>> GetNotificationsByThreadId(int id)
        {
            Data.Entities.Thread.Thread thread = await context.Threads
                .Include(e => e.Notifications)
                .FirstAsync(p => p.Id == id);
            return thread.Notifications;
        }
        public async Task<List<Notification>> GetNotificationsByCommentId(int id)
        {
            Comment comment = await context.Comments
                .Include(e => e.Notifications)
                .FirstAsync(p => p.Id == id);
            return comment.Notifications;
        }
        public async Task<List<Notification>> GetNotificationsByTagId(int id)
        {
            Tag tag = await context.Tags
                .Include(e => e.Notifications)
                .FirstAsync(p => p.Id == id);
            return tag.Notifications;
        }

        public async Task<List<Notification>> GetNotificationsByReactionId(int id)
        {
            Reaction reaction = await context.Reactions
                .Include(e => e.Notifications)
                .FirstAsync(p => p.Id == id);
            return reaction.Notifications;
        }
        public async Task<List<Notification>> GetNotificationsByNotificationId(int id)
        {
            Notification notification = await context.Notifications
                .Include(e => e.Notifications)
                .FirstAsync(p => p.Id == id);
            return notification.Notifications;
        }
        /*public void CreateNotification(NotificationModel model, User Id)
        {
            Notification notification = new Notification()
            {
                Id = model.Id,
                NotificationId = model.NotificationId,
                Text = model.Text,

            };
            context.Notifications.Add(notification);
            context.SaveChanges();
            var userNotification = new NotificationApplicationUser();
            userNotification.Id = notification.Id;

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
            Text = a.Text,
            Id = a.Id
        }).ToList();

        public void ReadNotification(int notificationId, string userId)
        {
            var notifications = context.UserNotifications
                                        .FirstOrDefault(n => n.UserId.Equals(userId)
                                        && n.NotificationId == notificationId);
            notifications.IsRead = true;
            context.UserNotifications.Update(notifications);
            context.SaveChanges();
        }*/
    }
}
