using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace AstralForum.Data.Entities.Comment
{
    public class Comment : MetadataBaseEntity
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; } //ParentCommentId
        public int AuthorId { get; set; }
        public List<Reaction.CommentReaction> Reactions { get; set; }
        public List<CommentAttachment> Attachments { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag.Tag> Tags { get; set; }
        public Thread.Thread Thread { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
 
