using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities
{
    public class MetadataBaseEntity : BaseEntity
    {
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User CreatedBy { get; set; } = null!;

        [ForeignKey(nameof(CreatedBy))]
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public MetadataBaseEntity()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
