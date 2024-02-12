using AstralForum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.ServiceModels
{
    public class MetaBaseEntityDto : BaseEntityDto
    {
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User CreatedBy { get; set; } = null!;

        [ForeignKey(nameof(CreatedBy))]
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public MetaBaseEntityDto()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
