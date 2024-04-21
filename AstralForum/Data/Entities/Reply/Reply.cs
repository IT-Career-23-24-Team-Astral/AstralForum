using AstralForum.Data.Entities.Reply;
using AstralForum.Data.Entities.Thread;
using Microsoft.Extensions.Hosting;

namespace AstralForum.Data.Entities.Reply
{
    public class Reply : MetadataBaseEntity
    {
        public int ReplyId { get; set; }
        public int ThreadId { get; set; }
        public int CommentId { get; set; }

        public string Text { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<ReplyReport> Reports { get; set; } = new HashSet<ReplyReport>();

        public ICollection<ReplyReaction> Reactions { get; set; } = new HashSet<ReplyReaction>();
    }
}
