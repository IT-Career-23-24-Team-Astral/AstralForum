using AstralForum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.ServiceModels
{
    public class MetaBaseEntityDto : BaseEntityDto
    {
        public UserDto CreatedBy { get; set; } = null!;

        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public MetaBaseEntityDto()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
