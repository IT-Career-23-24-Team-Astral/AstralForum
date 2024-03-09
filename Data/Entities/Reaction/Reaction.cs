using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities.Reaction
{
    public class Reaction : MetadataBaseEntity
    {
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Thread.Thread Thread { get; set; } = null!;

        [ForeignKey(nameof(Thread))]
        public int ThreadId { get; set; }

        public int CommentId { get; set; }
        public int ReactionTypeId { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}