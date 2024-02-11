using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Reply;

namespace AstralForum.Data.Entities._Notifications
{
    public class NotiReaction
    {
        public int NotificationId { get; set; }
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        public int ReactionId { get; set; }
        public int Id { get; set; }
        public ReactionType ReactionType { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
