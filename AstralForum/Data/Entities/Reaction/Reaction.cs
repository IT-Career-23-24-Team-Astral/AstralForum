using Microsoft.EntityFrameworkCore;

namespace AstralForum.Data.Entities.Reaction
{
    public class Reaction : MetadataBaseEntity
    {
        public int ThreadId { get; set; }

		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Thread.Thread Thread { get; set; }
        public int CommentId { get; set; }
        public int ReactionTypeId { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}
