using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Notification
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int NotificationId {  get; set; }
        public List<NotificationApplicationUser> NotificationApplicationUsers { get; set; }
    }
}