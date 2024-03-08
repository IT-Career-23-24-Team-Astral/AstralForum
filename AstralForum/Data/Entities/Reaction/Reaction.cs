using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities.Reaction
{
    public class Reaction : MetadataBaseEntity
    {
		[DeleteBehavior(DeleteBehavior.Restrict)]
        public Thread.Thread Thread { get; set; } = null!;

		public List<Notification> Notifications { get; set; }

		[ForeignKey(nameof(Thread))]
		[Required]
		public int ThreadId { get; set; }

		public int CommentId { get; set; }
        public int ReactionTypeId { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}