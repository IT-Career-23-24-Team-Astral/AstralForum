using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities
{
    public class Ban : MetadataBaseEntity
    {
        public string Reason { get; set; }
        public DateTime BanEnd { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User AffectedUser { get; set; }

        [ForeignKey(nameof(AffectedUser))]
        public int AffectedUserId { get; set; }
    }
}
