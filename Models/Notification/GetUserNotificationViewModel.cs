using AstralForum.ServiceModels;

namespace AstralForum.Models.Notification
{
	public class GetUserNotificationViewModel
	{
		public int NotificationId { get; set; }
		public int UserId { get; set; }
		public UserDto User { get; set; }
		public string Text { get; set; }
		public bool IsRead { get; set; }
		public int Count { get; set; }
		public DateTime Date { get; set; }
	}
}
