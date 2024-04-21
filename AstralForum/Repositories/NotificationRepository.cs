using AstralForum.Data.Entities;

using AstralForum.Mapping;
using AstralForum.ServiceModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Threading;


namespace AstralForum.Repositories
{
	public class NotificationRepository : CommonRepository<Notification>
	{
		private ApplicationDbContext context;

		public NotificationRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<List<Notification>> GetUserReadNotifications(int userId)
		{
			return await context.Notifications
				.Where(n => n.UserId == userId && n.IsRead == true)
				.Include(n => n.User)
				.ToListAsync();
		}
		public async Task<List<Notification>> GetUserNotifications(int userId)
		{
			return await context.Notifications
				.Where(n => n.UserId == userId && !n.IsRead)
				.Include(n => n.User)
				.ToListAsync();
		}
		public async Task<Notification> ReadNotification(int notificationId, int userId)
		{
			var notification = context.Notifications
				.FirstOrDefault(n => n.UserId == userId && n.Id == notificationId);

			if (notification != null)
			{
				notification.IsRead = true;
				context.Notifications.Update(notification);
				await context.SaveChangesAsync();
				return notification;
			}
			else
			{
				return null;
			}
		}


	}
}